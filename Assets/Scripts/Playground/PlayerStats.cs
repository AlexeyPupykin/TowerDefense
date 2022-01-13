using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int Waves;
    public static int Rounds;
    
    public int startMoney = 400;
    public int startLives = 20;    
    public int startWaves = 5;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Waves = startWaves;
        Rounds = 0;
    }
}
