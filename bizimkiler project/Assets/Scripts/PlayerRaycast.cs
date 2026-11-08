using System.Collections;
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.CompareTag("door"))
            {
                informationText.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.GetComponent<door>().openClose();
                    }
                }
            }
            else if (hit.collider.CompareTag("locking"))
            {
                informationText.SetActive(true);
                if (!isLocked)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.GetComponent<door>().openClose();
                    }
                }
                else if (isLocked)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        lockinfo.SetActive(true);
                        hit.collider.GetComponent<door>().locked();
                        YOKimg.SetActive(true);
                        audiosource.Play();
                        StartCoroutine(DisableImg());
                    }
                }
            }
            else if (hit.collider.TryGetComponent(out Book book))
            {

                informationText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    book.openClose();
                }
            }
            else if (hit.collider.TryGetComponent<Back>(out _))
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
        yield return new WaitForSeconds(5);
        YOKimg.SetActive(false);

    }

}
