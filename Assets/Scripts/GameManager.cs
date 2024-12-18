using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject fighter;
    [SerializeField] GameUIHandler gameUIHandler;

   
    //[SerializeField] GameObject titleScreen;

    [SerializeField] Texture2D cursorTexture;

    int portalIntergrity = 10;
    float score = 0;
    int waveCount = 0;

    float spawnPosY = 13;
    float spawnPosX = 22.5f;

    public int maxEnemyCount = 50;
    public float enemyCount;
    int waveEnemyCount = 5;

    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();    
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= 0 && isGameActive)
        {
            WaveCounter();
            if (waveCount % 4 == 0) 
            {
                StartBossFight();
                
                for (int i = 0; i < waveEnemyCount; i++)
                {
                    StartCoroutine(SpawnEnemies());
                }
            }
            else
            {
                
                for (int i = 0; i < waveEnemyCount; i++)
                {
                    StartCoroutine(SpawnEnemies());
                }
            }
        }
    }

   
    public void ReducePortalIntegrity(int damageAmount)
    {
        portalIntergrity -= damageAmount;
        gameUIHandler.SetPortalIntegrityText(portalIntergrity);

        if (portalIntergrity <= 0)
        {
            Time.timeScale = 0;
            GameOver();
        }
    }

    public void StartGame()
    {
        Cursor.SetCursor(cursorTexture, Vector2.up, CursorMode.Auto);
        Time.timeScale = 1.0f;
        isGameActive = true;

        portalIntergrity = 10;
        gameUIHandler.SetPortalIntegrityText(portalIntergrity);
        
        if (MainManager.Instance.highestScore != 0)
        {
            gameUIHandler.SetHighestScoreText();
        }
        

        if (MainManager.Instance.playerName != "")
        {
            gameUIHandler.SetPlayerNameText(MainManager.Instance.playerName);
        }
        else
        {
            int randomIndex = Random.Range(1, 500);
            gameUIHandler.SetPlayerNameText("Player" + randomIndex);
            MainManager.Instance.playerName = "Player" + randomIndex;
        } 
    }

    void GameOver()
    {
        isGameActive = false;
        gameUIHandler.restartScreen.SetActive(true);

        Cursor.SetCursor(null, Vector2.up, CursorMode.Auto);


        if (score > MainManager.Instance.highestScore)
        {
            MainManager.Instance.highestScore = score;
            MainManager.Instance.highestScoreName = MainManager.Instance.playerName;
            Debug.Log(MainManager.Instance.highestScoreName + "  " + MainManager.Instance.highestScore);
            gameUIHandler.SetHighestScoreText();
            MainManager.Instance.SaveHighestScore();
        } 
    }


    IEnumerator SpawnEnemies()
    {
        int randomEnemyIndex;
        randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        enemyCount++;
        yield return new WaitForSeconds(0.4f);
        Instantiate(enemyPrefabs[randomEnemyIndex], GenerateRandomPos(), enemyPrefabs[randomEnemyIndex].transform.rotation);
        
    }

    void WaveCounter()
    {
        
        waveCount++;
        gameUIHandler.SetWaveCountText(waveCount);
        

        if (waveEnemyCount < maxEnemyCount) 
        { 
        waveEnemyCount += 5;
        }
    }

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
        gameUIHandler.SetScoreText(score);
        
    }

    void StartBossFight()
    {
        enemyCount++;
        Vector3 spawnPosition = new Vector3(0,0,0);
        int leftright;
        leftright = Random.Range(0, 2);
        if (leftright == 0) 
        { 
            spawnPosition = new Vector3(-26, 0, 0.1f);
        }
        if (leftright == 1)
        {
            spawnPosition = new Vector3(26, 0, 0.1f);
        }

        Instantiate(boss, spawnPosition, boss.transform.rotation);

        //StartCoroutine(SpawnFighters());
    }

    //IEnumerator SpawnFighters()
    //{
        //yield return new WaitForSeconds(Random.Range(0.4f, 2));
       // Instantiate(fighter, RandomFighterPosition(), fighter.transform.rotation);
    //}

    Vector3 GenerateRandomPos()
    {
        float randomY = Random.Range(-spawnPosY, spawnPosY);
        float randomX = Random.Range(-spawnPosX, spawnPosX);

        int side;
        side = Random.Range(0, 4);

        Vector3 result = new Vector3(0,0,0);
        
        if (side == 0)
        {
            result = new Vector3(-spawnPosX, randomY, -0.1f);
        }
        if (side == 1)
        {
            result = new Vector3(randomX, spawnPosY, -0.1f);
        }
        if (side == 2) 
        {
            result = new Vector3(spawnPosX, randomY, -0.1f);
        }
        if (side == 3)
        {
            result = new Vector3(randomX, -spawnPosY, -0.1f);
        }

        return result;
                
    }

    Vector3 RandomFighterPosition()
    {
        Vector3 result;
        result = new Vector3((boss.transform.position.x + Random.Range(-5.0f, 5.0f)), (boss.transform.position.y + Random.Range(-5.0f, 5.0f)), -0.15f);
        return result;
    }
}
