using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelector : MonoBehaviour
{
    public Sprite[] shipSprites;
    public Button shipButtonPrefab;

    public Sprite selectedSprite {  get; private set; }
    public System.Action<Sprite> OnShipChanged;

    List<Button> shipButtons = new List<Button>();
    public void Init()
    {
        foreach (var sprite in shipSprites)
        {
            var newButton = Instantiate(shipButtonPrefab, transform);
            newButton.GetComponent<Image>().sprite = sprite;

            newButton.onClick.AddListener(() =>
            {
                selectedSprite = sprite;
                foreach (var button in shipButtons)
                {
                    button.interactable = true;
                }

                newButton.interactable = false;
                OnShipChanged.Invoke(selectedSprite);
            });
            shipButtons.Add(newButton);
        }
    }
    public void SelectShip(Sprite sprite)
    {
        for (int i = 0; i < shipSprites.Length; i++)
        {
            if (shipSprites[i] == sprite)
            {
                shipButtons[i].onClick.Invoke();
            }
        }
    }
}
