using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    private int counter = 0;
    public Text winText;
    public GameObject gameOver;
    public Button gameOverBt;



    private void Awake()
    {
        SetGCReferenceOnButtons();
        playerSide = "X";
    }

    void SetGCReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGCReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        if ((buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) || 
            (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) ||
            (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) ||

            (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) ||
            (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) ||
            (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) ||

            (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) ||
            (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide))
        {
            
            GameOver();
            
        }

        ChangeSides();

        if (counter == 9)
        {
            GameOver();
            
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X" ? "O" : "X");
        counter += 1;
        
    }

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        if (counter == 9)
        {
            winText.text = "Draw";

        } else
        {
            winText.text = playerSide + " WON";
        }
        

        gameOver.active = true;
    }

    public void BtReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

