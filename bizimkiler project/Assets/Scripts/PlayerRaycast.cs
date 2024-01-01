using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject informationText;
    public float interactionDistance;
    public LayerMask layers;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.gameObject.GetComponent<door>())
            {
                informationText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<door>().openClose();
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
                informationText.SetActive(false);
            }
        }
        else
        {
            informationText.SetActive(false);
        }
    }
}
