using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> weaponObjs;

    [SerializeField]
    private List<GameObject> weaponIconObjs;

    [SerializeField]
    private int currentSelectedIndex;




    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < weaponObjs.Count; i++) {
        //    if (i == currentSelectedIndex)
        //    {
        //        weaponIconObjs[i].GetComponent<Icon>().SetEnable(true);
        //        weaponObjs[i].SetActive(true);
        //    }
        //    else {
        //        weaponIconObjs[i].GetComponent<Icon>().SetEnable(false);
        //        weaponObjs[i].SetActive(false);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weaponObjs.Count; i++)
        {
            if (i == currentSelectedIndex)
            {
                weaponIconObjs[i].GetComponent<Icon>().SetEnable(true);
                weaponObjs[i].SetActive(true);
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
