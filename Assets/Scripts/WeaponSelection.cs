using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//IM2073 Project
public class WeaponSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> weaponObjs;

    [SerializeField]
    private List<GameObject> weaponIconObjs;

    [SerializeField]
    private int currentSelectedIndex;

    void Update()
    {
        for (int i = 0; i < weaponObjs.Count; i++)
        {
            if (i == currentSelectedIndex)
            {
                weaponIconObjs[i].GetComponent<Icon>().SetEnable(true);
                weaponObjs[i].SetActive(true);
                weaponObjs[i].GetComponentInChildren<WeaponController>().isAttacking = false;
            }
            else
            {
                weaponIconObjs[i].GetComponent<Icon>().SetEnable(false);
                weaponObjs[i].SetActive(false);
            }
        }
    }

    public void SelectLeftWeapon(InputAction.CallbackContext context) {
        if (context.performed) {
            currentSelectedIndex--;
            if (currentSelectedIndex < 0) {
                currentSelectedIndex = weaponObjs.Count - 1;
            }
        }
    }
    public void SelectRightWeapon(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentSelectedIndex++;
            if (currentSelectedIndex > weaponObjs.Count-1)
            {
                currentSelectedIndex = 0;
            }
        }
    }
}
//End Code