using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IM2073 Project
public class WaveSpawner : MonoBehaviour
{
    public enum State { Spawning, PlayerFighting, Waiting};

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public EnemyType[] enemy;
        public float spawnTime;
        public float spawnRate;
    }
    
    [System.Serializable]
    public class EnemyType
    {
        public Transform monsterName;
        public int count;
    }
    
    public Wave[] waves;
    public ChickenNPC chickenNPC;
    public GameStageController gameController;
    public Transform[] spawnPoints; //store defined spawnpoints

    private int nextWave = 0;
    private float searchCountdown = 1f;

    public State spawnerState = State.Waiting;

    void Start()
    {
        //Check for referenced spawn points
        if(spawnPoints.Length == 0)
        {
            Debug.Log("ERROR: No spawn points referenced.");
        }
    }

    void Update()
    {
        if (spawnerState == State.PlayerFighting)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                Debug.Log("No more enemies.");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
    }

    //Check for Enemies
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 2f; //every 2 sec to save computation power
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    public void StartSpawning()
    {
        if (spawnerState != State.Spawning)
        {
            Debug.Log("StartSpawning is called.");
            StartCoroutine(SpawnWave(waves[nextWave]));
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        spawnerState = State.Spawning;
        for(int i = 0; i < _wave.enemy.Length; i++)
        {
            for(int j = 0; j < _wave.enemy[i].count; j++)
            {
                SpawnEnemy(_wave.enemy[i].monsterName);
                yield return new WaitForSeconds(_wave.spawnTime / _wave.spawnRate); //wait for certain time until spawn enemy again
            }
        }
        spawnerState = State.PlayerFighting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Transform _spawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)]; //randomly choose a spawn point to spawn enemy
        Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
    }
    
    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        spawnerState = State.Waiting;
        gameController.SwitchMusicStage();
        chickenNPC.NextPhase();
        if (nextWave + 1 > waves.Length - 1) //- 1 because nextWave starts from 0 
        {
            nextWave = 0;
            Debug.Log("All waves completed.");
        }
        else
        {
            nextWave++; //moves to next wave
        }
    }
}
//End Code