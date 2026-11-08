using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;

    private AudioSource attackAudioSource;
    private GameObject cachedSword;
    private Animator swordAnimator;

    void Awake()
    {
        attackAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                SwordAttack();
            }
        }
    }


    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        if (cachedSword != Sword || swordAnimator == null)
        {
            cachedSword = Sword;
            swordAnimator = Sword.GetComponent<Animator>();
        }
        swordAnimator.SetTrigger("Attack");
        if (attackAudioSource == null)
        {
            attackAudioSource = GetComponent<AudioSource>();
        }
        attackAudioSource.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }


    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
