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
    // Start is called before the first frame update
    void Start()
    {
        scoreAdded = false;
        gameController = GameObject.Find("Canvas").transform.GetComponent<GameStageController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreAdded && (animator.GetBool("Die") || animator.GetBool("IsDead")))
        {
            gameController.AddScore(carriedScore);
            scoreAdded = true;
        }
    }
    private void OnDestroy()
    {
        //gameController = GameObject.Find("Canvas").transform.GetComponent<GameStageController>();
        //Animator animator = GetComponent<Animator>();
        //if (animator.GetBool("Die") || animator.GetBool("IsDead")) {
        //    gameController.AddScore(carriedScore);
        //}
       
    }
}
