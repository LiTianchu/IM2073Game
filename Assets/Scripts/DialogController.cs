using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{


    [SerializeField]
    private PlayerController pc;
    public string dialogText { get; set; }
    public NPC dialogNPC { get; set; }

    private TextMeshProUGUI tmPro;
    private int pgNo;
    private int maxPage;
    // Start is called before the first frame update

    void Start()
    {
        tmPro = GetComponentInChildren<TextMeshProUGUI>();
        pgNo = dialogNPC.startingDialogPageNo;
        // maxPage = dialogNPC.dialogTextList.Count-1;
        tmPro.text = dialogNPC.dialogTextList[0];

    }

    // Update is called once per frame
    void Update()
    {
        maxPage = dialogNPC.endingDialogPageNo;
        if (pgNo <= maxPage)
        {
            tmPro.text = dialogNPC.dialogTextList[pgNo];
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
        if (dialogNPC.optionPageNo != pgNo)
        {
            FlipDialogPage();
        }

    }

    public void FlipDialogPage()
    {
        pgNo++;
        if (pgNo == dialogNPC.optionPageNo)
        {
            dialogNPC.DisplayOptions();
        }
        else {
            dialogNPC.HideOptions(); 
        }
        if (pgNo > maxPage)
        {
            EndDialog();
        }
    }
    public void EndDialog() {
        pc.isTalking = false;
        pgNo = dialogNPC.startingDialogPageNo;
        tmPro.text = dialogNPC.dialogTextList[0];
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
