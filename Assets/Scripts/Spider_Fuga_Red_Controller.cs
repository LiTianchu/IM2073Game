using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Fuga_Red_Controller : MonoBehaviour
{
    public GameObject spiderAttackHitbox;

    // Start is called before the first frame update
    void Start()
    {
        spiderAttackHitbox = GetComponentInChildren<GameObject>(false);

        spiderAttackHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spider attack animation, activate hitbox
    void Attacking()
    {
        spiderAttackHitbox.SetActive(true);
    }

    // Spider attack animation, deactivate hitbox
    void StopAttacking()
    {
        spiderAttackHitbox.SetActive(false);
    }
}
