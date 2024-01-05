using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private GameObject rail = null;
    [SerializeField] private GameObject rail1 = null;
    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0f;
    [SerializeField] private AudioSource doorClosedAudioSource = null;
    [SerializeField] private float closeDelay = 0f;
    [SerializeField] private AudioSource locksound = null;


    bool toggle;
    public Animator anim;

    public void openClose()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            anim.ResetTrigger("open");
            anim.SetTrigger("close");
            doorClosedAudioSource.PlayDelayed(closeDelay);
        }
        if (toggle == true)
        {
            anim.ResetTrigger("close");
            anim.SetTrigger("open");
            doorOpenAudioSource.PlayDelayed(openDelay);
        }
    }
    public void locked()
    {
        locksound.PlayDelayed(0f);
        Destroy(rail);
        Destroy(rail1);
    }
}
