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
    [SerializeField]
    private GameObject gameSuccessScreen;

    public int numberOfKills { get; set; }
    public int score { get; set; }

    private bool peacefulStage;

    void Start()
    {
        score = 0;
        peacefulStage = true;
    }

    public void SwitchMusicStage() {
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

    public void AddKill(int kill)
    {
        this.numberOfKills += kill;
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void GameCompleted() {
        Time.timeScale = 0;
        gameSuccessScreen.SetActive(true);
    }
}
