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

    // Start is called before the first frame update
    void Start()
    {
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
        dialogController.FlipDialogPage();
        gameStageController.SwitchStage();
        Debug.Log("Mission Started");
    }

    public void DialogEnd() {
        HideOptions();
        dialogController.EndDialog();
    }

    
}
