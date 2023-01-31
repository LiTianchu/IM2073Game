using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    private GameStageController gameController;
    [SerializeField]
    private int carriedScore;
    private bool scoreAdded;
    private Animator animator;

    void Start()
    {
        scoreAdded = false;
        gameController = GameObject.Find("Canvas").transform.GetComponent<GameStageController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!scoreAdded && (animator.GetBool("Die") || animator.GetBool("IsDead")))
        {
            gameController.AddScore(carriedScore);
            scoreAdded = true;
        }
    }
}