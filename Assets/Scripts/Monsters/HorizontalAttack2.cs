using System;
using UnityEngine;

//right to left straight attack(disappear at the end)
public class HorizontalAttack2 : MiniMonster_Parent
{
    private void Start()
    {
        currentHp = maxHp;
        speed = 10f;
        int rand = UnityEngine.Random.Range(1, Managers.Field.GetHeight());    //처음 스폰 위치 결정      


        transform.position = Managers.Field.GetGrid(Managers.Field.GetWidth() - 1, rand).transform.position;
        current_X = Managers.Field.GetWidth() - 1;
        current_Y = rand;

        move_X = Managers.Field.GetWidth() - 1;
        move_Y = rand;

        //Debug.Log("Start :  Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("Start : current_X,current_Y:" + current_X + " ," + current_Y);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //소환되는 애니메이션 실행
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1의 비트 마다 실행할 BitBehave 구독
        Managers.Timing.BehaveAction += AutoBitBehave;
    }

    private void FixedUpdate()
    {
        try
        {
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);


            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);

            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));//-----------------

            current_X = move_X;
            current_Y = move_Y;

            currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = Color.magenta;

        }
        catch (ArgumentOutOfRangeException)
        {
            move_X = current_X;
            move_Y = current_Y;
        }
    }

    protected override void AutoBitBehave()
    {
        switch (nextBehavior)
        {
            case Define.State.ATTACKREADY:

                AutoWarningAttack(nextDirection);            //아래 grid는 빨강화로 공격할것임을 알린다
                break;

            case Define.State.ATTACK:                        //다음 박자에 아래로 이동 밑 공격

                AutoAttack(nextDirection);
                break;

            case Define.State.DIE:

                Die();
                break;

        }
    }

    protected override void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        SelectNextDirection();

        //Debug.Log("******current_X,current_Y:" + current_X + " ," + current_Y);
        try
        {
            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            //Debug.Log("LL shoud die ArgumentOutOfRangeException");
            nextBehavior = Define.State.DIE;
            return;
        }
        catch (NullReferenceException)
        {
            //Debug.Log("LL shoud die NullReferenceException");
            nextBehavior = Define.State.DIE;
            return;
        }
        nextBehavior = Define.State.ATTACK;
    }

    protected override void AutoAttack(Define.PlayerMove nextDirection)
    {
        mayGo(nextDirection);

        //Debug.Log("Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("current_X,current_Y:" + current_X + " ," + current_Y);

        StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));

        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        nextDirection = Define.PlayerMove.Left;
        a = -1; b = 0;
    }

    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die 할 GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Monster.CurrentHMons.Remove(gameObject);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = new Color(255f, 255f, 255f, 1);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        currentHp -= 1;
        if (currentHp <= 0)
        {
            nextBehavior = Define.State.DIE;
        }

    }


}