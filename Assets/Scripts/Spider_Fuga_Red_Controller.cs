using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Fuga_Red_Controller : MonoBehaviour
{
    public GameObject attackBoxGameObject;
    public BoxCollider spiderAttackHitbox;

    // Start is called before the first frame update
    void Start()
    {
        spiderAttackHitbox = attackBoxGameObject.GetComponent<BoxCollider>();

        spiderAttackHitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spider attack animation, activate hitbox
    void Attacking()
    {
        spiderAttackHitbox.enabled = true;
    }

    // Spider attack animation, deactivate hitbox
    void StopAttacking()
    {
        spiderAttackHitbox.enabled = false;
    }
}
