using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//IM2073 Project
public class DialogController : MonoBehaviour
{
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private AudioClip nextPageClip;

    public string dialogText { get; set; }
    public NPC dialogNPC { get; set; }

    private TextMeshProUGUI tmPro;
    private AudioSource audioSource;
    private int pgNo;
    private int maxPage;

    void Start()
    {
        tmPro = GetComponentInChildren<TextMeshProUGUI>();
        pgNo = 0;
        audioSource = GetComponent<AudioSource>();
        tmPro.text = dialogNPC.dialogTextList[dialogNPC.currentPhase].text[0];
    }

    void Update()
    {
        maxPage = dialogNPC.dialogTextList[dialogNPC.currentPhase].text.Count;
        if (pgNo <= maxPage)
        {
            tmPro.text = dialogNPC.dialogTextList[dialogNPC.currentPhase].text[pgNo];
        }
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
        else 
        {
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
}
//End Code