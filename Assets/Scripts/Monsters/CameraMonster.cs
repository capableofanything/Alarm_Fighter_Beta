using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMonster : Character
{
    Define.State nextBehavior = Define.State.SPAWN;

    [SerializeField] List<GameObject> horizontalMons = new List<GameObject>();      //가로 공격 몬스터용
    [SerializeField] List<GameObject> verticalMons = new List<GameObject>();          //세로 공격 몬스터용
    [SerializeField] List<GameObject> randomMons = new List<GameObject>();         //랜덤 공격 몬스터용

    List<CameraBeatManager.FunctionPointer> callOrderList;
    //public Transform CurrentTransform() { return transform; }//sunho 0218

    //public delegate void FunctionPointer();

    int index = 0;

    void Start()
    {
        Managers.Timing.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Timing.BehaveAction += BitBehave;

        callOrderList = Managers.CameraBeat.CreateCallOrderList();

        /*        CallOrderList.Add(Pattern1);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern1);
        */
    }
    //start sunho 0218
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < Managers.Field.GetWidth(); i++)
            {
                Managers.MonsterAttack.LazerAttack(this.transform, i, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Managers.MonsterAttack.FlashAttack();

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Managers.MonsterAttack.LazerMoveAttack(this.transform);

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Managers.MonsterAttack.LazerAttack(this.transform, 5, 1);
            Managers.MonsterAttack.LazerAttack(this.transform, 6, 1);
        }
    }
    //end


    void BitBehave()
    {
        if (index > callOrderList.Count - 1) // 4 재사용성 없음, 다른 것으로 대체될 수 있음
            index = 0;

        callOrderList[index]();
        index++;

        switch (nextBehavior)
        {
            case Define.State.SPAWN:

                //세로 공격 몬스터 스폰
                if (Managers.Monster.CurrentVMons.Count < 2) //필드에 2개 이상 만들어지지 않음
                {
                    SpawnVerticalMonster();
                }

                //가로 공격 몬스터 스폰
                if (Managers.Monster.CurrentHMons.Count < 1) //필드에 1개 이상 만들어지지 않음
                {
                    //SpawnHorizontalMonster( );
                }

                //랜덤 공격 몬스터 스폰
                if (Managers.Monster.CurrentRMons.Count < 1) //필드에 1개 이상 만들어지지 않음
                {
                    //SpawnRandomMonster( );
                }

                nextBehavior = Define.State.NOTSPAWN;
                break;


            case Define.State.NOTSPAWN:

                nextBehavior = Define.State.SPAWN;
                break;

        }
    }

    private void SpawnVerticalMonster()
    {
        //randomly spawn one monster in verticalMons List
        //int rand = UnityEngine.Random.Range(0, verticalMons.Count);
        //GameObject go = Instantiate<GameObject>(verticalMons[rand]);

        GameObject go = Instantiate<GameObject>(verticalMons[0]);
        Managers.Monster.CurrentVMons.Add(go);
    }

    private void SpawnHorizontalMonster()
    {
        //randomly spawn one monster in horizontalMons List
        //int rand = UnityEngine.Random.Range(0, horizontalMons.Count);
        //GameObject go = Instantiate<GameObject>(horizontalMons[rand]);

        GameObject go = Instantiate<GameObject>(horizontalMons[0]);
        Managers.Monster.CurrentHMons.Add(go);
    }

    private void SpawnRandomMonster()
    {
        //randomly spawn one monster in randomMons List
        //int rand = UnityEngine.Random.Range(0, randomMons.Count);
        //GameObject go = Instantiate<GameObject>(randomMons[rand]);

        GameObject go = Instantiate<GameObject>(randomMons[0]);
        Managers.Monster.CurrentRMons.Add(go);
    }



    private void OnTriggerEnter2D(Collider2D collision)                 //Player의 공격으로 인해서 몬스터가 활성화된 grid에 닿을 경우
    {

    }

}