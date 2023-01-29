using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageController : MonoBehaviour
{
    [SerializeField]
    private MusicPlayer musicPlayer;

    private bool peacefulStage;
    // Start is called before the first frame update
    void Start()
    {
        peacefulStage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchStage() {
        if (peacefulStage) {
            musicPlayer.ChangeClip(1);
            peacefulStage = false;
            Debug.Log("Battle Stage");
        }
        else {
            musicPlayer.ChangeClip(0);
            peacefulStage = true;
            Debug.Log("Peace Stage");
        }
   
    }
}
