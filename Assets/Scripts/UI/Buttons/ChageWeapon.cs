using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageWeapon : MonoBehaviour            //WeaponChange(GameObject)������ ��ư�鿡 ���Ե�
{
    public void toWoodSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;
        Destroy(go.GetComponent<Weapon>());         //Player(clone)(GameObject)�� Weapon�� ��� ���� ���� ��ũ��Ʈ�� ��ȯ

        go.AddComponent<WoodSword>();
    }

    public void toDiaSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;

        Destroy(go.GetComponent<Weapon>());

        go.AddComponent<Sword>();

    }
}
