using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNPC : NPC
{
    [SerializeField]
    private GameObject optionsObj;
    [SerializeField]
    private DialogController dialogController;
    [SerializeField]
    private GameStageController gameStageController;
    [SerializeField]
    private AudioClip interactSFX;
    [SerializeField]
    private AudioClip declineSFX;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        base.InitNPC();
    }

    // Update is called once per frame
    void Update()
    {
        base.UpdateNPC();
    }

    public override void DisplayOptions()
    {
        optionsObj.SetActive(true);
    }

    public override void HideOptions()
    {
        optionsObj.SetActive(false);
    }

    public void StartMission() {
        audioSource.PlayOneShot(interactSFX);
        dialogController.FlipDialogPage();
        gameStageController.SwitchStage();
        Debug.Log("Mission Started");
    }

    public void DialogEnd() {
        audioSource.PlayOneShot(declineSFX);
        HideOptions();
        dialogController.EndDialog();
    }

    
}
