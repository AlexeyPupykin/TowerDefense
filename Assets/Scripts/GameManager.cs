using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool IsContinue;
    public static bool GameIsWin;
    public GameObject gameWinUI;
    public GameObject gameOverUI;

    public void Continue()
    {
        IsContinue = true;
        gameWinUI.SetActive(false);
    }

    private void Start()
    {
        GameIsOver = false;
        GameIsWin = false;
        IsContinue = false;
    }

    private void Update()
    {
        if (GameIsOver)
            return;

        if (GameIsWin && !IsContinue)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();
        
        if(!IsContinue && !GameIsWin && PlayerStats.Waves == PlayerStats.Rounds && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            WinGame();
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    private void WinGame()
    {
        GameIsWin = true;
        gameWinUI.SetActive(true);
    }
}
