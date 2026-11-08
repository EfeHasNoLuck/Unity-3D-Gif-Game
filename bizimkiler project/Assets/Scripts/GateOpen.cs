using System.Collections;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject cutcontrol;
    public GameObject player;
    public GameObject canvas;
    
    bool a = false;
    bool b = false;
    bool work = true;
    int value = 0;

    void Update()
    {
        if (a && b && value == 0 && work)
        {
            StartCoroutine(Cutscene());
        }
    }

    IEnumerator Cutscene()
    {
        work = false;
        cutcontrol.SetActive(true);
        player.SetActive(false);
        canvas.SetActive(false);
        yield return new WaitForSeconds(26f);
        cutcontrol.SetActive(false);
        player.SetActive(true);
        canvas.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("a"))
        {
            a = true;
        }
        if (other.CompareTag("b"))
        {
            b = true;
        }
        if (other.CompareTag("c"))
        {
            value = value + 1;
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("a"))
        {
            a = false;
        }
        if (other.CompareTag("b"))
        {
            b = false;
        }
        if (other.CompareTag("c"))
        {
            value = value - 1;
        }
    }
}
