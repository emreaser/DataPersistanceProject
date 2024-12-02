using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI portalIntegrityText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI highestScoreText;
    public GameObject restartScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPortalIntegrityText(int integrity)
    {
        portalIntegrityText.text = "Portal Integrity " + integrity.ToString();
    }

    public void SetScoreText(float score)
    { 
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetWaveCountText(int waveCount)
    {
        waveCountText.text = "Wave: " + waveCount.ToString();
    }

    public void SetPlayerNameText(string playerName)
    {
        playerNameText.text = playerName;
    }

    public void SetHighestScoreText()
    {
       highestScoreText.text = MainManager.Instance.highestScoreName + " - " + MainManager.Instance.highestScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
