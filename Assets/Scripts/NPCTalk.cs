using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCTalk : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private GameObject dialogComponent;
    [SerializeField]
    private GameObject controlHintComponent;
    [SerializeField]
    private PlayerController pc;
    private DialogController dc;
   
    private bool playerAround;
    // Start is called before the first frame update
    void Start()
    {
        dc = dialogComponent.GetComponent<DialogController>();
    }

    public void ShowDialogOptionOnScreen(GameObject npcObj) {
        if (playerAround)
        {
            controlHintComponent.SetActive(true);
            dc.dialogNPC = npcObj.GetComponent<NPC>();
        }
        else {
            HideDialogOption();
        }
    }

    public void HideDialogOption() {
        controlHintComponent.SetActive(false);
        dc.dialogNPC = null;
    }

    public void Talk(InputAction.CallbackContext context) {
        if (context.performed && controlHintComponent.activeSelf) {
            pc.isTalking = true;
            controlHintComponent.SetActive(false);
            dialogComponent.SetActive(true);
        }
    }
}
