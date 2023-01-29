using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    public List<string> dialogTextList;
    [SerializeField]
    private NPCInteractionController npcController;
    [SerializeField]
    public int startingDialogPageNo;
    [SerializeField]
    public int endingDialogPageNo;
    [SerializeField]
    public int optionPageNo;

    private BoxCollider npcCollider;
    // Start is called before the first frame update
   

    public void InitNPC() {
        npcCollider = GetComponent<BoxCollider>();
    }

    public void UpdateNPC() {
        Collider[] colliders = Physics.OverlapBox(npcCollider.bounds.center, npcCollider.bounds.extents * 2.6f, Quaternion.identity, playerLayer);

        npcController.playerAroundNPC = colliders.Length > 0;
    }

    public virtual void DisplayOptions() { 
    
    }

    public virtual void HideOptions()
    {

    }
}
