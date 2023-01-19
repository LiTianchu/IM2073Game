using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float gravity;

    private CharacterController cc;
    private Rigidbody rb;
    private Vector3 movement;
    private float horizontalLookInput;
    private float verticalLookInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y -= gravity * Time.deltaTime;
        //stop gravity from stacking
        if (cc.isGrounded && movement.y < 0)
        {
            movement.y = -0.3f;
        }

        cc.Move(transform.TransformDirection(movement) * walkSpeed * Time.deltaTime);
        Vector3 playerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(playerRotation.x, playerRotation.y + horizontalLookInput * rotateSpeed * Time.deltaTime, playerRotation.z));
        //  movement = transform.TransformDirection(movement);
    }

    public void Walk(InputAction.CallbackContext context)
    {

        movement = context.ReadValue<Vector3>();
        //     movement = transform.TransformDirection(movement);

    }

    public void Look(InputAction.CallbackContext context)
    {

        //   Debug.Log(context.ReadValue<Vector2>());

        horizontalLookInput = context.ReadValue<Vector2>().x;
        verticalLookInput = context.ReadValue<Vector2>().y;
        //  movement = transform.TransformDirection(movement);


    }
}
