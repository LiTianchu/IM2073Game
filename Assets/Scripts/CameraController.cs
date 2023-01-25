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

    private float verticalLookInput;
    private float timePassed;
    private float timeToEnableRotation;

    // Start is called before the first frame update
    void Start()
    {
      //  transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        timePassed = Time.time;
        timeToEnableRotation = timePassed + rotationLockTime;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= timeToEnableRotation) {
            Vector3 cameraRotation = transform.rotation.eulerAngles;
            float angle = transform.rotation.eulerAngles.x - verticalLookInput * rotateSpeed * Time.deltaTime;

            if (angle >= 360 - rotationAngle || angle <= 0 + rotationAngle)
            {
                transform.rotation = Quaternion.Euler(new Vector3(cameraRotation.x - verticalLookInput * rotateSpeed * Time.deltaTime, cameraRotation.y, cameraRotation.z));
            }
        }
      
        //   Debug.Log(transform.rotation.eulerAngles);
    }

    public void Look(InputAction.CallbackContext context)
    {

        //   Debug.Log(context.ReadValue<Vector2>());
        if (timePassed >= timeToEnableRotation)
        {
            // horizontalLookInput = context.ReadValue<Vector2>().x;
            verticalLookInput = context.ReadValue<Vector2>().y;
            //  movement = transform.TransformDirection(movement);
        }

    }
}
