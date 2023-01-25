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

    private bool weaponSelected;
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
        weaponHitbox = GetComponent<BoxCollider>();
        weaponHitbox.enabled = false;
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
        //Vector3 weaponRotation = transform.rotation.eulerAngles;
        //float angle = transform.rotation.eulerAngles.x - verticalLookInput * rotateSpeed * Time.deltaTime;

        //if (angle >= 360 - rotationAngle || angle <= 0 + rotationAngle)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(weaponRotation.x - verticalLookInput * rotateSpeed * Time.deltaTime, weaponRotation.y, weaponRotation.z));
        //}
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && isAttacking==false)
        {
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
        isAttacking = true;
        yield return new WaitForSeconds(attackClip.length + 0.1f);
        anim.SetBool("IsAttacking", false);
        isAttacking = false;
    }
}
