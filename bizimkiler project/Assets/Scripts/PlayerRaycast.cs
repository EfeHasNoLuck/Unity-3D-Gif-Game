using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject backinfo;
    public GameObject informationText;
    public GameObject lockinfo;
    public float interactionDistance;
    public LayerMask layers;
    public static bool isLocked = true;
    public GameObject YOKimg;
    public AudioSource audiosource;

    void Start()
    {
        YOKimg.SetActive(false);
    }

    void Update()
    {
        Debug.Log(isLocked);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.gameObject.tag == "door")
            {
                informationText.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<door>().openClose();
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "locking")
            {
                informationText.SetActive(true);
                if (!isLocked)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<door>().openClose();
                    }
                }
                else if (isLocked)
                {
                    //  lockinfo.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        lockinfo.SetActive(true);
                        hit.collider.gameObject.GetComponent<door>().locked();
                        YOKimg.SetActive(true);
                        audiosource.Play();
                        StartCoroutine(DisableImg());
                    }
                }
            }
            else if (hit.collider.gameObject.GetComponent<Book>())
            {

                informationText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Book>().openClose();
                }
            }
            else if (hit.collider.gameObject.GetComponent<Back>())
            {
                backinfo.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + +1);
                }
            }
            else
            {
                backinfo.SetActive(false);
                lockinfo.SetActive(false);
                informationText.SetActive(false);
            }
        }
        else
        {
            backinfo.SetActive(false);
            lockinfo.SetActive(false);
            informationText.SetActive(false);
        }
    }
    IEnumerator DisableImg()
    {
        Debug.Log("a");
        yield return new WaitForSeconds(5);
        YOKimg.SetActive(false);

    }

}
