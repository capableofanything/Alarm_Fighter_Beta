using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingRange : MonoBehaviour
{

    [SerializeField] RectTransform[] timingRect = null;
    //private Vector2[] timingRange = null; //timingRect�� x����

   /* public Vector2[] GetTimingRange()
    {
        return timingRange;
    }*/

    void Start()
    {
        Managers.Timing.timingRange = new Vector2[timingRect.Length]; //ũ�� 4

        for (int i = 0; i < timingRect.Length; i++)
        {
            //timingRange[0]�� perfectRect�� ���� ��
            Managers.Timing.timingRange[i] = new Vector2(timingRect[i].localPosition.x - timingRect[i].rect.width / 2,
                timingRect[i].localPosition.x + timingRect[i].rect.width / 2);
        }
    }
    
}
