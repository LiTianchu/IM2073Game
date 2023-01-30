using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageController : MonoBehaviour
{
    [SerializeField]
    private MusicPlayer musicPlayer;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOverScreen;

    private int score;
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

    public void PauseGame() {
     Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
   public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddScore(int score) {
        this.score += score;
    }
    public void GameOver() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
