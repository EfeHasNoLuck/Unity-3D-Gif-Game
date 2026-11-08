using System.Collections;
using UnityEngine;

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
        if (other.CompareTag("Player"))
        {
            YOKimg.SetActive(true);
            audiosource.Play();
            StartCoroutine(DisableImg());
        }
     
    }

     IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(5);
        YOKimg.SetActive(false);

    }


}
