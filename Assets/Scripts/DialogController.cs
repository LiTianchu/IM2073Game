using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    

    [SerializeField]
    private PlayerController pc;
    public string dialogText { get; set;}
    public NPC dialogNPC { get; set; }

    private TextMeshProUGUI tmPro;
    private int pgNo;
    private int maxPage;
    // Start is called before the first frame update

    void Start()
    {
        tmPro = GetComponentInChildren<TextMeshProUGUI>();
        pgNo = 0;
       // maxPage = dialogNPC.dialogTextList.Count-1;
        tmPro.text = dialogNPC.dialogTextList[0];
       
    }

    // Update is called once per frame
    void Update()
    {
        maxPage = dialogNPC.dialogTextList.Count - 1;
        if (pgNo <= maxPage)
        {
            tmPro.text = dialogNPC.dialogTextList[pgNo];
        }
    }

    public void NextPage() {
        pgNo++;
        if (pgNo > maxPage) {
            pc.isTalking = false;
            pgNo = 0;
            tmPro.text = dialogNPC.dialogTextList[0];
            this.gameObject.SetActive(false);
        }
    
    }

    
}
