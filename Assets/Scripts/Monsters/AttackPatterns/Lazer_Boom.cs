using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Lazer_Boom : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        Invoke("Destroy", 0.3f);
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
    //void Update()
    //{
    //    float alpha = rend.color.a;
    //    if (alpha <= 0)
    //    {
    //        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.6f);
    //        Managers.Resource.Destroy(gameObject);
    //        return;
    //    }

    //    alpha -= 0.01f;
    //    rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
    //}
}
