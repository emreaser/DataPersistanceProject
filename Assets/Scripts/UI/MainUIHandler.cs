using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public ShipSelector shipSelector;
    public TMP_InputField inputField;
    public TextMeshProUGUI highestScore;

    public void NewShipSelected(Sprite sprite)
    {
        MainManager.Instance.shipSprite = sprite;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        shipSelector.Init();
        shipSelector.OnShipChanged += NewShipSelected;
        shipSelector.SelectShip(MainManager.Instance.shipSprite);

        if (MainManager.Instance.playerName != null) 
        { 
        inputField.text = MainManager.Instance.playerName;
        }

        if (MainManager.Instance.highestScore != 0)
        {
        highestScore.text = MainManager.Instance.highestScoreName + " - " + MainManager.Instance.highestScore.ToString();
        } 

    }

    // Update is called once per frame
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        MainManager.Instance.playerName = inputField.text;
        
    }
}
