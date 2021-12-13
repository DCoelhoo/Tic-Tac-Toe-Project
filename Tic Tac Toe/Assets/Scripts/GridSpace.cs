using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public string playerSide;

    private GameController gc;

    public void SetGCReference(GameController controller)
    {
        gc = controller;
    }

    public void SetSpace()
    {
        buttonText.text = gc.GetPlayerSide();
        button.interactable = false;
        gc.EndTurn();
    }
}
