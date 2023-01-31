using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField]
    private NPCInteractionController npcInteraction;
    [SerializeField]
    private float raycastingDist;
    [SerializeField]
    private PlayerController playerController;
    private RaycastHit objectHit;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd,out objectHit, raycastingDist))
        {
            if (objectHit.transform != null && !playerController.isTalking)
            {
                string layerName = LayerMask.LayerToName(objectHit.transform.gameObject.layer);
                if (layerName.Equals("NPC"))
                {
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