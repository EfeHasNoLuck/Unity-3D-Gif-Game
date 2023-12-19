using UnityEngine;

private bool aCollided = false;
private bool bCollided = false;
private bool cCollided = false;

void Update()
{
    // Reset the boolean flags at the beginning of each frame
    aCollided = false;
    bCollided = false;
    cCollided = false;
}

void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("A"))
    {
        // A has collided
        aCollided = true;
    }
    else if (collision.gameObject.CompareTag("B"))
    {
        // B has collided
        bCollided = true;
    }
    else if (collision.gameObject.CompareTag("C"))
    {
        // C has collided
        cCollided = true;
    }

    // Check the condition and delete the object accordingly
    CheckCollisionCondition();
}

void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("A"))
    {
        // A is no longer in contact
        aCollided = false;
    }
    else if (collision.gameObject.CompareTag("B"))
    {
        // B is no longer in contact
        bCollided = false;
    }
    else if (collision.gameObject.CompareTag("C"))
    {
        // C is no longer in contact
        cCollided = false;
    }

    // Check the condition and delete the object accordingly
    CheckCollisionCondition();
}

void CheckCollisionCondition()
{
    if (aCollided && bCollided && !cCollided)
    {
        // Delete the object associated with this script
        Destroy(gameObject);
    }
}
