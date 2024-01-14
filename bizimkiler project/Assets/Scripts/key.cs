using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class key : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        PlayerRaycast.isLocked = false;
        if (other.tag == "Player")
        {
           Destroy(gameObject);
        }
    }
}
