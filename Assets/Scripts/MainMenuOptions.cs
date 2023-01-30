using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour, IPointerEnterHandler
{
    private enum SceneType
    {
        GameStart,
        Credit,
        Controls,
        Exit,
    };
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hoverSound;
    [SerializeField]
    private AudioClip clickSound;
    [SerializeField]
    private SceneType sceneType;
    [SerializeField]
    private GameObject creditScreen;
    [SerializeField]
    private GameObject controlScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData ped)
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void ButtonClicked()
    {
        audioSource.PlayOneShot(clickSound);
        if (sceneType == SceneType.GameStart)
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (sceneType == SceneType.Credit)
        {
            creditScreen.SetActive(true);
        }
        else if (sceneType == SceneType.Controls)
        {
            controlScreen.SetActive(true);
        }
        else if (sceneType == SceneType.Exit)
        {
            Application.Quit();
        }
    }

    public void HideCredit()
    {
        creditScreen.SetActive(false);
    }

    public void HideControl()
    {
        controlScreen.SetActive(false);
    }


}
