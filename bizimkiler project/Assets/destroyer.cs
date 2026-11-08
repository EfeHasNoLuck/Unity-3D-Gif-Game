using UnityEngine;

public class destroyer : MonoBehaviour
{

    public static int hp = 10;
    void Update()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
