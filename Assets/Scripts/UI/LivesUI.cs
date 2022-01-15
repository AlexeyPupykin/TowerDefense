using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    private void Update()
    {
        if(PlayerStats.Lives < 0)
            livesText.text = 0 + " LIVES";
        else
            livesText.text = PlayerStats.Lives.ToString() + " LIVES"; 
    }
}
