using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMonster : Character
{
    Define.State nextBehavior = Define.State.SPAWN;

    [SerializeField] List<GameObject> horizontalMons = new List<GameObject>();      //���� ���� ���Ϳ�
    [SerializeField] List<GameObject> verticalMons = new List<GameObject>();          //���� ���� ���Ϳ�
    [SerializeField] List<GameObject> randomMons = new List<GameObject>();         //���� ���� ���Ϳ�

    List<CameraBeatManager.FunctionPointer> callOrderList;
    //public Transform CurrentTransform() { return transform; }//sunho 0218

    //public delegate void FunctionPointer();

    int index = 0;

    void Start()
    {
        Managers.Timing.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
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
        if (index > callOrderList.Count - 1) // 4 ���뼺 ����, �ٸ� ������ ��ü�� �� ����
            index = 0;

        callOrderList[index]();
        index++;

        switch (nextBehavior)
        {
            case Define.State.SPAWN:

                //���� ���� ���� ����
                if (Managers.Monster.CurrentVMons.Count < 2) //�ʵ忡 2�� �̻� ��������� ����
                {
                    SpawnVerticalMonster();
                }

                //���� ���� ���� ����
                if (Managers.Monster.CurrentHMons.Count < 1) //�ʵ忡 1�� �̻� ��������� ����
                {
                    //SpawnHorizontalMonster( );
                }

                //���� ���� ���� ����
                if (Managers.Monster.CurrentRMons.Count < 1) //�ʵ忡 1�� �̻� ��������� ����
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



    private void OnTriggerEnter2D(Collider2D collision)                 //Player�� �������� ���ؼ� ���Ͱ� Ȱ��ȭ�� grid�� ���� ���
    {

    }

}