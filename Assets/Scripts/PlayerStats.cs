using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public static int Waves;
    public int startWaves = 5;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Waves = startWaves;

        Rounds = 0;
    }
}
