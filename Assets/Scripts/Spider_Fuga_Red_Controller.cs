using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IM2073 Project
public class Spider_Fuga_Red_Controller : MonoBehaviour
{
    public GameObject attackBoxGameObject;
    public BoxCollider spiderAttackHitbox;

    void Start()
    {
        spiderAttackHitbox = attackBoxGameObject.GetComponent<BoxCollider>();
        spiderAttackHitbox.enabled = false;
    }

    void Attacking()
    {
        spiderAttackHitbox.enabled = true;
    }

    void StopAttacking()
    {
        spiderAttackHitbox.enabled = false;
    }
}
//End Code