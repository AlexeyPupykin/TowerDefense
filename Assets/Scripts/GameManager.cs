using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    public static bool GameIsWin;
    public GameObject gameWinUI;

    public static bool IsContinue;

    private void Start()
    {
        GameIsOver = false;
        GameIsWin = false;
        IsContinue = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if(!IsContinue && !GameIsWin && PlayerStats.Waves < PlayerStats.Rounds)
        {
            WinGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    void WinGame()
    {
        GameIsWin = true;
        gameWinUI.SetActive(true);
    }

    public void Continue()
    {
        IsContinue = true;
        gameWinUI.SetActive(false);
    }
}
