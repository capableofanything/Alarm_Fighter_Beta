using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        //Transform go =transform.root;    //Canvas(GameObject)�� ��ȯ��    //���� ��ũ��Ʈ�� �ٿ��� ������Ʈ�� �ֻ��� ������Ʈ(StagePrologueMenu) ��ȯ
        GameObject go = GameObject.Find("StagePrologueMenu");
        go.transform.GetChild(0).gameObject.SetActive(true);           //BlackFrame(GameObject)
        go.transform.GetChild(1).gameObject.SetActive(true);           //GreenPage(GameObject)
        go.GetComponent<StagePrologueMenu>().SettingSong();
        go.GetComponent<StagePrologueMenu>().play();
      
    }
}
