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
    [SerializeField]
    private AudioClip missionSuccessSFX;
    [SerializeField]
    private WaveSpawner spawnerManager;
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
        List<GameObject> options = base.dialogTextList[currentPhase].option;
        foreach (Transform child in optionsObj.transform) {
            if (options.Contains(child.gameObject))
            {
                child.gameObject.SetActive(true);
            }
            else {
                child.gameObject.SetActive(false);
            }
        }
        
    }

    public override void HideOptions()
    {
        optionsObj.SetActive(false);
    }

    public void StartMission() {
        audioSource.PlayOneShot(interactSFX);
        dialogController.FlipDialogPage();
        gameStageController.SwitchMusicStage();
        spawnerManager.StartSpawning();
        Debug.Log("Mission Started");
    }

    public void DialogEnd() {
        audioSource.PlayOneShot(declineSFX);
        HideOptions();
        dialogController.EndDialog();
    }

    public void MissionSuccess()
    {
        audioSource.PlayOneShot(missionSuccessSFX);
        HideOptions();
        dialogController.EndDialog();
        gameStageController.GameCompleted();
    }

    public void NextPhase() {
        if (base.currentPhase < base.dialogTextList.Count - 1) {
            base.currentPhase++;
        }
    }

    
}
