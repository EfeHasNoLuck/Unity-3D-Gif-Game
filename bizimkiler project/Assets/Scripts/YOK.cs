using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YOK : MonoBehaviour
{
    public GameObject YOKimg;
    public AudioSource audiosource;




    void Start()
    {
        YOKimg.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("a");
            YOKimg.SetActive(true);
            audiosource.Play();
            StartCoroutine(Disableimg());
        }
     
    }

     IEnumerator Disableimg()
    {
        yield return new WaitForSeconds(2);
        YOKimg.SetActive(false);

    }


}
