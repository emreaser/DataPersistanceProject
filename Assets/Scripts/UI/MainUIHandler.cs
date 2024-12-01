using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public ShipSelector shipSelector;

    public void NewShipSelected(Sprite sprite)
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        shipSelector.Init();
        shipSelector.OnShipChanged += NewShipSelected;
        //shipSelector.SelectShip();
    }

    // Update is called once per frame
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    
}
