using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//IM2073 Project
public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    private GameStageController gameController;
    private TextMeshProUGUI tmPro;

    void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tmPro.text = gameController.score + "";
    }
}
//End Code