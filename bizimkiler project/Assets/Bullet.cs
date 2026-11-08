using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bossy"))
        {
            destroyer.hp--;
        }
    }
}
