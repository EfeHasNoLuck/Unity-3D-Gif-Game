using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && wc.isAttacking)
        {
            Debug.Log("selamaaa");
        }
    }
}
