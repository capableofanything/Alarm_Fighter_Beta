using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour           //Note2(Prefab)�� ����     //��Ʈ �Ѱ��� ������ �������� ���
{
    public float noteSpeed = 0;
    Image noteImage;//Note(��ü)�� Image 
    
    private void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;  

    }

    void OnEnable()//��ü�� Ȱ��ȭ �� �� ���� ����
    {
        if (noteImage == null)
        {
            noteImage = GetComponent<Image>();
        }
        noteImage.enabled = true;       //w,a,s,d,k �� �������� ��ü�� �̹����� ��Ȱ��ȭ �Ͽ��� ������ ����
    }


    //Note�� �̹����� ��Ȱ��ȭ �ϴ� �Լ�
    public void HideNote()
    {
        noteImage.enabled = false;
    }
    //--------------------------------------------------------------------------
    /*public void CreateNote()
    {
        Transform parent = transform.parent;
        GameObject go = Managers.Resource.Instantiate("Note", parent);
        go.GetComponent<Animator>().speed = Managers.Bpm.GetAnimSpeed();
    }

    public void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }*/
}
