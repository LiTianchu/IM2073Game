using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float rotationAngle;
    [SerializeField]
    private float rotationLockTime;
    [SerializeField]
    private PlayerController pc;

    private float verticalLookInput;
    private float timePassed;
    private float timeToEnableRotation;
    
    void Start()
    {
        timePassed = Time.time;
        timeToEnableRotation = timePassed + rotationLockTime;
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= timeToEnableRotation && !pc.isTalking) {
            Vector3 cameraRotation = transform.rotation.eulerAngles;
            float angle = transform.rotation.eulerAngles.x - verticalLookInput * rotateSpeed * Time.deltaTime;

            if (angle >= 360 - rotationAngle || angle <= 0 + rotationAngle)
            {
                transform.rotation = Quaternion.Euler(new Vector3(cameraRotation.x - verticalLookInput * rotateSpeed * Time.deltaTime, cameraRotation.y, cameraRotation.z));
            }
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        if (timePassed >= timeToEnableRotation)
        {
            verticalLookInput = context.ReadValue<Vector2>().y;
        }
    }
}
