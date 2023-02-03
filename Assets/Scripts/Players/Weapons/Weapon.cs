using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected string weapon;            //(����)Prefab ��ΰ� ����� ����
    public int Damage { get; protected set;}
    //to do : Effect



    private void Start()
    {
        Init();                         //WeaponŬ������ ��ӹ޴� �ڽ�Ŭ������ Init()�Լ��� �����
    }

    protected virtual void Init()
    {
        ArmWeapon();
    }

    public virtual int[] CalculateAttackRange(int currentInd)
    {
        return new int[1] { currentInd };     //ũ�� 1�� (int ��)�迭�� �����ϰ� currentInd�� �ʱ�ȭ
    }

    public virtual void ArmWeapon()     //Player�� ��� �ִ� ���� �ʱ� ����
    {
        if (weapon == null)             //������ ���Ⱑ ���ٸ�
            return;

        GameObject go = Util.FindChild(gameObject, "Hand");     //���� ��ũ��Ʈ�� ���� Player(GameObject)�� �ڽ� �� Hand(GameObject)�� ã��
        Managers.Resource.Instantiate(weapon, go.transform);    //������ ���� ����( Hand(GameObject)������ ����)
    }
}
