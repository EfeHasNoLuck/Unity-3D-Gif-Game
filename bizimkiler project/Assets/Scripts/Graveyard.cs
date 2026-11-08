using UnityEngine;
using UnityEngine.SceneManagement;

public class Graveyard : MonoBehaviour
{
    public void Buta()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

