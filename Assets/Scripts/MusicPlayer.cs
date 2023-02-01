using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IM2073 Project
public class MusicPlayer : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip[] musicArray;
    private AudioClip currentClip;
   
    private void Start()
    {
        currentClip = musicArray[0];
        BGM.PlayOneShot(musicArray[0]);
    }
    private void Update()
    {
        if (BGM.isPlaying == false)
        {
            BGM.PlayOneShot(currentClip, 0.5f);
        }
    }

    public void ChangeClip(int index) {//0 peace music, 1 battle music
        currentClip = musicArray[index];
        BGM.Stop();
        BGM.PlayOneShot(currentClip,0.5f);
    }
}
//End Code