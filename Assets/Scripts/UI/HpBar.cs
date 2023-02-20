using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Slider slider;

    public float maxValue;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void updateValue(float currentHP, float maxHP)      //Slider ������Ʈ �ʱ�ȭ
    {
        slider.value = currentHP / maxHP;
    }
}
