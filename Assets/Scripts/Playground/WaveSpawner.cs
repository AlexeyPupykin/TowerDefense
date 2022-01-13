using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{
    private float countdown = 2f;
    private int waveIndex = 0;

    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;
    public List<Wave> waves;
    public List<Enemy> enemies;
    public Transform spawnPoint;
    public Text waveCounterText;

    private void Update()
    {
        if (PlayerStats.Waves == PlayerStats.Rounds && !GameManager.IsContinue || GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            return;

        if(countdown <= 0f)
        {
            if (GameManager.GameIsWin && !GameManager.IsContinue)
                return;

            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        if(GameManager.IsContinue)
            waveCounterText.text = PlayerStats.Rounds.ToString();
        else
            waveCounterText.text = PlayerStats.Rounds.ToString() + "/" + PlayerStats.Waves.ToString();
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        if (waves.Count >= waveIndex)
        {
            var currentCustomWave = waves.ElementAt(waveIndex - 1);

            for (int i = 0; i < currentCustomWave.enemyNumber; i++)
            {
                SpawnEnemy(enemies.Find(e => e.type == currentCustomWave.enemyType).prefab);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        else
        {
            for (int i = 0; i < waveIndex; i++)
            {
                if (waveIndex % 10 == 0)
                    SpawnEnemy(enemies.Find(e => e.type == EnemyType.Fat).prefab);
                else if (waveIndex % 5 == 0)
                    SpawnEnemy(enemies.Find(e => e.type == EnemyType.Fast).prefab);
                else
                    SpawnEnemy(enemies.Find(e => e.type == EnemyType.Standart).prefab);

                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }        
    }

    private void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

[System.Serializable]
public class Wave {
    public int enemyNumber;
    public EnemyType enemyType;
}
