using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
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
        GameObject go = GameObject.Find("StageMenu");
        go.transform.GetChild(0).gameObject.SetActive(false);
        go.transform.GetChild(1).gameObject.SetActive(false);
        Managers.Sound.StopBgm();
        //Managers.Sound.Clear();
        Managers.Scene.LoadScene("Stage2");
    }
}
