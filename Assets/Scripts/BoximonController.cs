using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoximonController : MonoBehaviour
{
    public GameObject boximonAttackBoxGameObject;
    public BoxCollider boximonAttackBox;

    // Start is called before the first frame update
    void Start()
    {
        boximonAttackBox = boximonAttackBoxGameObject.GetComponent<BoxCollider>();

        boximonAttackBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attacking()
    {
        boximonAttackBox.enabled = true;
    }

    void Stop_Attacking()
    {
        boximonAttackBox.enabled = false;
    }
}
