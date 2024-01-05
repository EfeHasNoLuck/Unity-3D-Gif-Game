using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject informationText;
    public GameObject lockinfo;
    public float interactionDistance;
    public LayerMask layers;
    public bool isLocked = false;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.gameObject.GetComponent<door>())
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
            else
            {
                lockinfo.SetActive(false);
                informationText.SetActive(false);
            }
        }
        else
        {
            lockinfo.SetActive(false);
            informationText.SetActive(false);
        }
    }
}
