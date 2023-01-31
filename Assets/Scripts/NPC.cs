using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [System.Serializable]
    public class Conversation
    {
        public List<string> text;
        public int phaseNo;
        public int optionPageNo;
        public List<GameObject> option;
    }

    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    public List<Conversation> dialogTextList;
    [SerializeField]
    private NPCInteractionController npcController;
    [SerializeField]
    public int currentPhase;

    private BoxCollider npcCollider;

    public void InitNPC() {
        npcCollider = GetComponent<BoxCollider>();
    }

    public void UpdateNPC() {
        Collider[] colliders = Physics.OverlapBox(npcCollider.bounds.center, npcCollider.bounds.extents * 2.6f, Quaternion.identity, playerLayer);
        npcController.playerAroundNPC = colliders.Length > 0;
    }

    public virtual void DisplayOptions() 
    { 
    
    }

    public virtual void HideOptions()
    {

    }
}
