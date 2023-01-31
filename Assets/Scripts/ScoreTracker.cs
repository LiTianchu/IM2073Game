using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    private GameStageController gameController;
    private TextMeshProUGUI tmPro;
    // Start is called before the first frame update
    void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmPro.text = gameController.score + "";
    }
}
