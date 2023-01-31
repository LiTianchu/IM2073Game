using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AnimationClip attackClip;
    [SerializeField]
    private AudioClip attackSFX;
    [SerializeField]
    private float audioPlayAtPercentageOfAnimationClip;
    [SerializeField]
    private PlayerController pc;

    private AudioSource audioSource;
    public GameObject bloodParticleSystem;
    private ContactPoint contactPoint;
    private Quaternion cPointRotation;
    private bool weaponSelected;
    private float nextAttackingTime;
    private float atkCoolDown;
    public bool isAttacking;

    // Storing hitbox collider
    public BoxCollider weaponHitbox;
    public CapsuleCollider weaponCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        weaponHitbox = GetComponent<BoxCollider>();
        weaponCollider = GetComponent<CapsuleCollider>();
        weaponHitbox.enabled = false;
        weaponCollider.enabled = false;
        nextAttackingTime = Time.time;
        atkCoolDown = attackClip.length + 0.1f;
    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            weaponSelected = true;
        }
        else {
            weaponSelected = false;
        }
        isAttacking = anim.GetBool("IsAttacking");
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && !anim.GetBool("IsAttacking") && Time.time>=nextAttackingTime && !pc.isTalking)
        {
            nextAttackingTime = Time.time+ atkCoolDown;
            StartCoroutine(PerformAttack());
        }
    }

    // Attack anim enable hitbox
    void Attacking()
    {
        weaponHitbox.enabled = true;
        weaponCollider.enabled = true;
    }

    // Attack anim disable hitbox
    void Stop_Attacking()
    {
        weaponHitbox.enabled = false;
        weaponCollider.enabled = false;
    }

    IEnumerator PerformAttack()
    {
        anim.SetBool("IsAttacking", true);
        
        yield return new WaitForSeconds(attackClip.length * audioPlayAtPercentageOfAnimationClip);
        audioSource.PlayOneShot(attackSFX);
        yield return new WaitForSeconds(attackClip.length * (1-audioPlayAtPercentageOfAnimationClip));
        anim.SetBool("IsAttacking", false);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("There is collision.");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Instantiating particle.");

            contactPoint = other.GetContact(0);
            cPointRotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
            var bloodEffect = Instantiate(bloodParticleSystem, contactPoint.point, cPointRotation);

            Destroy(bloodEffect, 0.4f);
        }
    }
}
