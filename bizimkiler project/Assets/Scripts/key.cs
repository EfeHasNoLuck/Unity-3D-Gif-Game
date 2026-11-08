using UnityEngine;

public class key : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        PlayerRaycast.isLocked = false;
        if (other.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }
}
