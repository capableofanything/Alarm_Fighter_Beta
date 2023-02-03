using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    protected override void Init()
    {
        weapon = "Player/Weapons/Sword";
        Damage = 2;
        base.Init();
    }
    public override int[] CalculateAttackRange(int currentInd)
    {
        int[] pattern = new int[2];                 //2ĭ ����
        for (int i = 0; i < pattern.Length; i++)
        {
            currentInd += 3;                        //Player���� �� �� ĭ
            pattern[i] = currentInd;

        }
        return pattern;
    }

}
