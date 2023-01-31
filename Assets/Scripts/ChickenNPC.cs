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
    private AudioClip hitSFX;
    [SerializeField]
    private AudioClip missionSuccessSFX;
    [SerializeField]
    private WaveSpawner spawnerManager;
    [SerializeField]
    private int healthPoint;
    private AudioSource audioSource;
    [SerializeField]
    HealthBar _healthBar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        base.InitNPC();
    }

    // Update is called once per frame
    void Update()
    {
        base.UpdateNPC();

        if (healthPoint <= 0)
        {
            gameStageController.GameOver();
        }
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

    // On being hit by enemies
    bool isColliding; // To prevent multiple OnTriggerEnter in one instance
    void OnTriggerEnter(Collider collision)
    {
        if (isColliding == true) return;
        isColliding = true;

        if (collision.gameObject.tag == "Enemy_Attack")
        {
            if (collision.gameObject.name == "Spider_Fuga_Red_AttackBox")
            {
                healthPoint -= 5;
                _healthBar.SetHealth(healthPoint);
            }

            if (collision.gameObject.name == "Boximon_AttackBox")
            {
                healthPoint -= 8;
                _healthBar.SetHealth(healthPoint);
            }
            audioSource.PlayOneShot(hitSFX);
        }

        StartCoroutine(Reset());
    }
    // Used in preventing multiple OnTriggerEnter in one instance
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}