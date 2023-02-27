using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelay : MonoBehaviour
{
    IEnumerator enumerator = null;

    private void Coroutine(IEnumerator coro)
    {
        enumerator = coro;
        StartCoroutine(coro);
    }

    void Update()
    {
        if (enumerator != null)
        {
            if (enumerator.Current == null)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Stop()
    {
        StopCoroutine(enumerator.ToString());
        Destroy(gameObject);
    }



    public static TimeDelay Start_Coroutine(IEnumerator coro)
    {
        GameObject obj = new GameObject("CoroutineHandler");
        TimeDelay handler = obj.AddComponent<TimeDelay>();
        if (handler)
        {
            handler.Coroutine(coro);
        }
        return handler;
    }
}


