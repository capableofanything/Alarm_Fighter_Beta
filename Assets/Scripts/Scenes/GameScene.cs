using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    int monsterIndex = 0;           //���� ���� �ε���(����� ��)
    int maxMonsterNum;              //�ִ� ���� ��      //monsters(List).Count �� �ʱ�ȭ��

    [SerializeField]

    List<GameObject> monsters = new List<GameObject>();     //��� �ʱ�ȭ? Inspectorâ�� ���콺 �巡��


    [SerializeField]
    GameObject backGround;

    int GetMaxMonsterNum() { return maxMonsterNum; }
    void SetMaxMonsterNum() { maxMonsterNum = monsters.Count; }

    public override void Clear()
    {
        Managers.Timing.Clear();
        monsters.Clear();
        monsterIndex = 0;       //?????
    }

    protected override void Init()
    {
        base.Init();            //base�� �θ� Ŭ������ �ǹ�
        SetMaxMonsterNum();
        Managers.Game.SetMonsterCount(maxMonsterNum);
        SoundBgmPlay();         //BaseScene�� ���
        SpawnMonster();
        SpawnBackGround();
        //SpawnNoteBar();
        SpawnPlayer();
        SpawnField();
        SpawnMoveButton();
        SpawnTimer();
        SpawnHpBarMiddle();

        //Managers.Item.Init();
        //Managers.Resource.Instantiate("Items/ItemBoxes/@GridBaseSpawn");
        //Managers.Menu.Init();

    }


    public void Update()
    {
        Managers.Timing.UpdatePerBit();         //�� ��Ʈ���� ���� �ൿ ����Ʈ
        Managers.Game.CheckLeftMonster();       //��� ���Ͱ� ����ϴ��� Ȯ��
    }
    private void SpawnMonster()                 //Ư�(monsterIndex) �ε��� ��° ���� ��
    {
        if (monsters.Count == 0) return;
        GameObject go = Instantiate(monsters[monsterIndex]) as GameObject;

        SpawnMonsterHpBar(go);
        Managers.Monster.BossMonster = go;
    }
    private void SpawnBackGround()              //
    {
        GameObject go = Instantiate(backGround) as GameObject;      //
        //go = Instantiate<GameObject>(go) as GameObject;     //?????
    }
    private void SpawnNoteBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Notes/NoteBar/NoteBar");
        go = Instantiate(go) as GameObject;
    }
    private void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/Player");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Player.SetPlayer(go.GetComponent<Character>());
        Managers.Game.CurrentPlayer = go;

        SpawnPlayerHpBar(go);
    }
    private void SpawnField()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Fields/RoundField1");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Field.SetField(go.GetComponent<RoundField>());
        Managers.Field.Init();
    }
    private void SpawnMoveButton()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MoveButton");
        go = Instantiate<GameObject>(go) as GameObject;

    }
    
    private void SpawnTimer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/Timer");
        go = Instantiate<GameObject>(go) as GameObject;

    }

    private void SpawnPlayerHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/PlayerHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        parent.GetComponent<HpBarUpdater>().hpbar = go;
        //GameObject go2 = Managers.Resource.Instantiate("Prefabs/UI/PlayerHpBar");
    }

    private void SpawnMonsterHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MonsterHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        parent.GetComponent<HpBarUpdater>().hpbar = go;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/MonsterHpBar");
    }
    private void SpawnHpBarMiddle()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/HpBarMiddle");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/HpBarMiddle");
    }

    public void NextMonsterIndex()                          //��� ���� ��
    {
        if (monsterIndex < maxMonsterNum - 1)
        {
            monsterIndex++;
            SpawnMonster();
        }
    }
}
