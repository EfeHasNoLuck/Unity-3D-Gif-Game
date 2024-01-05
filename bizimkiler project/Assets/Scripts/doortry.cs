using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortry : MonoBehaviour
{
    public CharacterController characterController;

    public GameObject character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(a());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }    

    IEnumerator a()
    {
        yield return new WaitForSeconds(0.01f);
        characterController.enabled = false;
        character.transform.position = new Vector3(-3.81999993f, 53.3800011f, 244.5f);
        characterController.enabled = true;
    }
}