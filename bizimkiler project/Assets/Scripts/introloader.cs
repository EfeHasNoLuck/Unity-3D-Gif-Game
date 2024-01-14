using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introloader : MonoBehaviour
{
    IEnumerator Loader()
    {
        yield return new WaitForSeconds(55.67f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loader());
    }


}


