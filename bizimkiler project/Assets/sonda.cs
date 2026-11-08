using System.Collections;
using UnityEngine;

public class sonda : MonoBehaviour
{

    public GameObject contmetni;
    public GameObject video;

 void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            video.SetActive(true);
            StartCoroutine(dakkabekle());
        }
    }

   IEnumerator dakkabekle()
    {
        yield return new WaitForSeconds(64);
        video.SetActive(true);
        contmetni.SetActive(true);
    }
}
