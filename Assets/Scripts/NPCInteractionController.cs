using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractionController: MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private GameObject dialogComponent;
    [SerializeField]
    private GameObject controlHintComponent;
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private TextMeshProUGUI nameHintText;
    [SerializeField]
    private TextMeshProUGUI controlHintText;
    [SerializeField]
    private AudioClip interactSFX;
    private DialogController dc;
    private AudioSource audioSource;
    public bool playerAroundNPC { get; set; }

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        dc = dialogComponent.GetComponent<DialogController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dc.dialogNPC != null)
        {
            nameHintText.text = dc.dialogNPC.name;
        }
        if (pc.isTalking)
        {
            controlHintComponent.SetActive(true);
            controlHintText.text = "Continue";
        }
        else {
            controlHintText.text = "Talk";
        }

    }

    public void ShowDialogOptionOnScreen(GameObject npcObj)
    {
        if (playerAroundNPC)
        {
            controlHintComponent.SetActive(true);
            dc.dialogNPC = npcObj.GetComponent<NPC>();

        }
        else
        {
            HideDialogOption();
        }
    }

    public void HideDialogOption()
    {
        controlHintComponent.SetActive(false);
       // dc.dialogNPC = null;
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && controlHintComponent.activeSelf)
        {
          //  hintText = controlHintComponent.GetComponentInChildren<TextMeshProUGUI>();
           
            if (!pc.isTalking)
            {
                audioSource.PlayOneShot(interactSFX);
                pc.isTalking = true;
                controlHintComponent.SetActive(false);
               
                dialogComponent.SetActive(true);
                if (dc.dialogNPC.optionPageNo == 0)
                {
                    dc.dialogNPC.DisplayOptions();
                }

            }
            else {
                dc.NextPage();
            }
         
        }
    }
}
