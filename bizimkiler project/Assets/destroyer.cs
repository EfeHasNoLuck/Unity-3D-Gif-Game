using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{

    public static int hp = 10;
    void Update()
    {
        Debug.Log(hp);
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
