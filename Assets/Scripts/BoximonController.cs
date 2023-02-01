using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IM2073 Project
public class BoximonController : MonoBehaviour
{
    public GameObject boximonAttackBoxGameObject;
    public BoxCollider boximonAttackBox;

    void Start()
    {
        boximonAttackBox = boximonAttackBoxGameObject.GetComponent<BoxCollider>();
        boximonAttackBox.enabled = false;
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
//End Code