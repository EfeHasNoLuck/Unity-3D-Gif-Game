using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    bool a = false;
    bool b = false;
    bool c = false;
    bool work = true;
    int value = 0;
    public GameObject Gate;

    void Update()
    {
        // Debug.Log(value);
        // Debug.Log(a);
        // Debug.Log(b);

        if (a && b && value == 0 && work)
        {
            Destroy(Gate);
            work = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "a")
        {
            a = true;
        }
        if (other.gameObject.tag == "b")
        {
            b = true;
        }
        if (other.gameObject.tag == "c")
        {
            value = value + 1;
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "a")
        {
            a = false;
        }
        if (other.gameObject.tag == "b")
        {
            b = false;
        }
        if (other.gameObject.tag == "c")
        {
            value = value - 1;
        }
    }


        

    /*      private void OnTriggerStay(Collider other)
          {
              if (other.gameObject.tag == "a")
              {
                  Debug.Log("staying");
              }
          }
    */
}