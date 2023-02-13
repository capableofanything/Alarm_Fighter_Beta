using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    List<Weapon> weaponList;


    public GameObject WeaponSpawn(int x, int y, Transform parent = null)
    {
        GameObject weapon = Managers.Resource.Instantiate("Items/ItemBoxes/WeaponBox");
        WeaponBox wpSet = weapon.GetComponent<WeaponBox>();

        wpSet.SetWeapon(NextWeapon());
        Managers.Field.ScaleByRatio(weapon, x, y);
        wpSet.SetNumOfAttack();
        wpSet.SetLocation(x, y);
        weapon.transform.SetParent(parent);

        Managers.Field.GetFieldInfo(x, y).spawnable = false;
        return weapon;

    }

    public void Init()
    {
        SetWeaponList();
    }

    public void SetWeaponList()
    {
        //to do : player ĳ���Ϳ� ���� weaponList �ٲ��
        weaponList = new List<Weapon>();
        weaponList.Add(new Sword());
    }

    Weapon NextWeapon()
    {
        //to do : Ȯ���� ���� ���� weapon ����
        return weaponList[0];
    }

}
