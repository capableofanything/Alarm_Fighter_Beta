using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void updateValue(int value)      //Slider ������Ʈ �ʱ�ȭ
    {
        Debug.Log($"{value} : updateValue");
        slider.value = value;
    }
}
