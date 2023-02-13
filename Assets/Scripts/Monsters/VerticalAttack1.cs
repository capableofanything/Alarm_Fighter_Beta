using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAttack1 : MiniMonster_Parent
{
    private void Start()
    {
        speed = 10f;
        int rand = UnityEngine.Random.Range(1, Managers.Field.GetWidth() - 1);

        transform.position = Managers.Field.GetGrid(rand, 0).transform.position;
        //transform.parent.transform.position = spawnGrid.transform.position;
        current_X = rand;
        current_Y = 0;

        move_X = rand;
        move_Y = 0;

        Debug.Log(rand);
        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //��ȯ�Ǵ� �ִϸ��̼� ����
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1�� ��Ʈ ���� ������ BitBehave ����
        Managers.Timing.BehaveAction += AutoBitBehave;
    }
    //Ư�� �׸��忡 ���� ���ڸ��� 

    //�Ʒ� �ݺ�
    //�Ʒ� grid�� ����ȭ�� �����Ұ����� �˸���
    //���� ���ڿ� �Ʒ��� �̵� �� ����

    //�� �̻� ������ grid �� �������� ���� ��� destroy

    public void AutoBitBehave()
    {
        switch (nextBehavior)
        {
            case Define.State.ATTACKREADY:

                AutoWarningAttack(nextDirection);            //�Ʒ� grid�� ����ȭ�� �����Ұ����� �˸���
                break;

            case Define.State.ATTACK:                        //���� ���ڿ� �Ʒ��� �̵� �� ����
                AutoAttack(nextDirection);
                break;

            case Define.State.DIE:
                Die();
                break;

        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        Debug.Log("Die �� GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Game.CurrentVMons.Remove(gameObject);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = new Color(255f, 255f, 255f, 1);
    }

    public void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        //�����غ� ������ �ִϸ��̼� ����
        //�Ʒ� grid ����ȭ
        try
        {
            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X, current_Y + 1).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            nextBehavior = Define.State.DIE;
            return;
        }
        nextBehavior = Define.State.ATTACK;
    }

    protected override void SelectNextDirection()
    {
        nextDirection = Define.PlayerMove.Down;
    }
    public void AutoAttack(Define.PlayerMove nextDirection)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Jump");
        SelectNextDirection();
        mayGo(nextDirection);
        
        try
        {
            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));
        }
        catch (ArgumentOutOfRangeException)
        {

        }
        nextBehavior = Define.State.ATTACKREADY;
    }
   
    private void FixedUpdate()
    {
        try
        {
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);

            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);

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
}
