using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicField : Field         //Field(GameObject)�� ���Ե�(�������� ����)
{
    public override void Setheight()    //Field�� Setheight()�� �������̵�
    {
        height = 5;
    }
   
    public override void setWidth()
    {
        width = 3;
    }

}
