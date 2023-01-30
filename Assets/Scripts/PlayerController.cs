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
    private float jumpSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private int healthPoint;
    [SerializeField]
    HealthBar _healthBar;

    public bool isTalking { get; set; }
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
        //if (cc.isGrounded)
        //{
        //    //doubleJumpAvailable = true;
        //    timeToStopBeingLenient = Time.time + jumpTimeLeniency;
        //    //Set the movement direction to be the received input, set y to 0 since we are on the ground
        //    moveDirection = new Vector3(leftRightInput, 0, forwardBackwardInput);

        //    //Set the move direction in relation to the transform
        //    moveDirection = transform.TransformDirection(moveDirection);
        //    moveDirection = moveDirection * moveSpeed;

        //    if (jumpPressed)
        //    {
        //        movement.y = jumpPower;
        //    }
        //}
        //else
        //{
        //    moveDirection = new Vector3(leftRightInput * moveSpeed, moveDirection.y, forwardBackwardInput * moveSpeed);
        //    moveDirection = transform.TransformDirection(moveDirection);

        //    //to give time leniency for ungrounded player to jump
        //    if (jumpPressed && Time.time < timeToStopBeingLenient)
        //    {
        //        moveDirection.y = jumpPower;
        //    }
        //    else if (jumpPressed && doubleJumpAvailable)
        //    {
        //        moveDirection.y = jumpPower;
        //        doubleJumpAvailable = false;

        //    }
        //}

        movement.y -= gravity * Time.deltaTime;
        //stop gravity from stacking
        if (cc.isGrounded && movement.y < 0)
        {
            movement.y = -0.3f;
        }
        Vector3 transformedMovement = transform.TransformDirection(movement);
        cc.Move(new Vector3(transformedMovement.x * walkSpeed * Time.deltaTime,transformedMovement.y * jumpSpeed * Time.deltaTime,transformedMovement.z * walkSpeed*Time.deltaTime));
        if (!isTalking)
        {
            Vector3 playerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(playerRotation.x, playerRotation.y + horizontalLookInput * rotateSpeed * Time.deltaTime, playerRotation.z));
        }
        //  movement = transform.TransformDirection(movement);
    }

    public void Walk(InputAction.CallbackContext context)
    {
        if (cc.isGrounded)
        {
            movement = context.ReadValue<Vector3>();
        }
        else {
            movement = new Vector3(context.ReadValue<Vector3>().x, movement.y, context.ReadValue<Vector3>().z);
        }
        //     movement = transform.TransformDirection(movement);

    }

    public void Look(InputAction.CallbackContext context)
    {

        //   Debug.Log(context.ReadValue<Vector2>());

        horizontalLookInput = context.ReadValue<Vector2>().x;
        verticalLookInput = context.ReadValue<Vector2>().y;
        //  movement = transform.TransformDirection(movement);


    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed && cc.isGrounded) {
            movement.y = jumpPower;
        }
    }

    // On being hit by enemies
    bool isColliding; // To prevent multiple OnTriggerEnter in one instance
    void OnTriggerEnter(Collider collision)
    {
        if (isColliding == true) return;
        isColliding = true;

        if (collision.gameObject.tag == "Enemy_Attack")
        {
            if (collision.gameObject.name == "Spider_Fuga_Red_AttackBox")
            {
                healthPoint -= 5;
                _healthBar.SetHealth(healthPoint);
                Debug.Log("Spider_Fuga_Red_AttackBox: " + healthPoint);
            }

            if (collision.gameObject.name == "Boximon_AttackBox")
            {
                healthPoint -= 8;
                _healthBar.SetHealth(healthPoint);
                Debug.Log("Boximon_AttackBox: " + healthPoint);
            }
        }

        StartCoroutine(Reset());
    }

    // Used in preventing multiple OnTriggerEnter in one instance
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}
