using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{


    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private AudioClip nextPageClip;

    ////To call WaveSpawner script and start spawning enemies
    //[SerializeField]
    //WaveSpawner waveSpawner;

    public string dialogText { get; set; }
    public NPC dialogNPC { get; set; }

    private TextMeshProUGUI tmPro;
    private AudioSource audioSource;
    private int pgNo;
    private int maxPage;
    // Start is called before the first frame update

    void Start()
    {
        tmPro = GetComponentInChildren<TextMeshProUGUI>();
        pgNo = 0;
        audioSource = GetComponent<AudioSource>();
        // maxPage = dialogNPC.dialogTextList.Count-1;
        tmPro.text = dialogNPC.dialogTextList[dialogNPC.currentPhase].text[0];
    }

    // Update is called once per frame
    void Update()
    {
        maxPage = dialogNPC.dialogTextList[dialogNPC.currentPhase].text.Count;
        if (pgNo <= maxPage)
        {
            tmPro.text = dialogNPC.dialogTextList[dialogNPC.currentPhase].text[pgNo];
        }
        //if (pgNo == dialogNPC.optionPageNo)
        //{
        //    dialogNPC.DisplayOptions();
        //}
        //if (pgNo != dialogNPC.optionPageNo)
        //{
        //    dialogNPC.HideOptions();
        //}
    }

    public void NextPage()
    {
        if (dialogNPC.dialogTextList[dialogNPC.currentPhase].optionPageNo != pgNo)
        {
            audioSource.PlayOneShot(nextPageClip);
            FlipDialogPage();
        }

    }

    public void FlipDialogPage()
    {
        pgNo++;
        if (pgNo == dialogNPC.dialogTextList[dialogNPC.currentPhase].optionPageNo)
        {
            dialogNPC.DisplayOptions();
        }
        else {
            dialogNPC.HideOptions(); 
        }
        if (pgNo > maxPage-1)
        {
            
            EndDialog();
        }
    }
    public void EndDialog() {
        pc.isTalking = false;
        pgNo = 0;
        tmPro.text = dialogNPC.dialogTextList[dialogNPC.currentPhase].text[0];
        this.gameObject.SetActive(false);
      
    }

    //public void DisplayDialogOptions() {
    //    if (pgNo == dialogNPC.optionPageNo)
    //    {
    //        dialogNPC.DisplayOptions();
    //    }
    //}

    //public void HideDialogOptions() {
    //    if (pgNo != dialogNPC.optionPageNo)
    //    {
    //        dialogNPC.HideOptions();
    //    }
    //}


}
