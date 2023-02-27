using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeatManager
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1 = new List<FunctionPointer>() { Pattern1, Pattern2, Pattern1, Pattern2, Pattern3, Pattern1, Pattern3, Pattern2 };

    private static void Pattern1()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.MonsterAttack.LazerAttack(Managers.Monster.BossMonster.transform, i, Managers.Player.GetCurrentY());
        }
        Debug.Log("Pattern 1");
    }
    private static void Pattern2()
    {
        // 아무것도 없음.
        Debug.Log("Pattern 2");
    }

    private static void Pattern3()
    {
        // int rand = UnityEngine.Random.Range(1, Managers.Field.GetWidth() - 1);
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.MonsterAttack.LazerAttack(Managers.Monster.BossMonster.transform, Managers.Player.GetCurrentX(), i);
        }
    }
    public List<FunctionPointer> CreateCallOrderList()
    {
        List<FunctionPointer> callOrderList = new List<FunctionPointer>();
        for (int i = 0; i < noteBarList_1.Count; i++)
        {
            callOrderList.Add(noteBarList_1[i]);
        }

        return callOrderList;
    }
}