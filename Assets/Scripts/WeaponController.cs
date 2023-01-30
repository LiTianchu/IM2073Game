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
    private bool weaponSelected;
    private float nextAttackingTime;
    private float atkCoolDown;
    public bool isAttacking;
    //[SerializeField]
    //private int rotationAngle;
    //[SerializeField]
    //private float rotateSpeed;

    //private float verticalLookInput;


    // Storing hitbox collider
    public BoxCollider weaponHitbox;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        weaponHitbox = GetComponent<BoxCollider>();
        weaponHitbox.enabled = false;
        nextAttackingTime = Time.time;
        atkCoolDown = attackClip.length + 0.1f;
    }

    // Update is called once per frame
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
        //Vector3 weaponRotation = transform.rotation.eulerAngles;
        //float angle = transform.rotation.eulerAngles.x - verticalLookInput * rotateSpeed * Time.deltaTime;

        //if (angle >= 360 - rotationAngle || angle <= 0 + rotationAngle)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(weaponRotation.x - verticalLookInput * rotateSpeed * Time.deltaTime, weaponRotation.y, weaponRotation.z));
        //}
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && !anim.GetBool("IsAttacking") && Time.time>=nextAttackingTime && !pc.isTalking)
        {
         //   isAttacking = true;
            
            nextAttackingTime += atkCoolDown;
            StartCoroutine(PerformAttack());
        }
    }

    // Attack anim enable hitbox
    void Attacking()
    {
        weaponHitbox.enabled = true;
    }

    // Attack anim disable hitbox
    void Stop_Attacking()
    {
        weaponHitbox.enabled = false;
    }

    //public void Look(InputAction.CallbackContext context)
    //{

    //    //   Debug.Log(context.ReadValue<Vector2>());

    //    // horizontalLookInput = context.ReadValue<Vector2>().x;
    //    verticalLookInput = context.ReadValue<Vector2>().y;
    //    //  movement = transform.TransformDirection(movement);


    //}

    IEnumerator PerformAttack()
    {
        anim.SetBool("IsAttacking", true);
        
        yield return new WaitForSeconds(attackClip.length * audioPlayAtPercentageOfAnimationClip);
        audioSource.PlayOneShot(attackSFX);
        yield return new WaitForSeconds(attackClip.length * (1-audioPlayAtPercentageOfAnimationClip));
        anim.SetBool("IsAttacking", false);
     //   isAttacking = false;
    }
}
