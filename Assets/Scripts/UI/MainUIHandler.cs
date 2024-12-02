using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public ShipSelector shipSelector;
    public InputField nameInputField;

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
    }

    // Update is called once per frame
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        MainManager.Instance.playerName = nameInputField.text.ToString();
        Debug.Log(MainManager.Instance.playerName);
    }
}
