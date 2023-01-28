using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField]
    private NPCInteractionController npcInteraction;
    [SerializeField]
    private float raycastingDist;
    private RaycastHit objectHit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
    //    Debug.DrawRay(transform.position, fwd * 65, Color.green);
        if (Physics.Raycast(transform.position, fwd,out objectHit, raycastingDist))
        {
            //do somet$$anonymous$$ng if $$anonymous$$t object ie
            if (objectHit.transform != null)
            {
                string layerName = LayerMask.LayerToName(objectHit.transform.gameObject.layer);
                if (layerName.Equals("NPC"))
                {
                    ResetAllInteraction();
                    HandleNPCInteraction(objectHit.transform.gameObject);
                }
                else {
                    ResetAllInteraction();
                }
            }
        }
    }

    private void HandleNPCInteraction(GameObject npcObj) {
        npcInteraction.ShowDialogOptionOnScreen(npcObj);
    }

    private void ResetAllInteraction() {
        npcInteraction.HideDialogOption();
    }
}

