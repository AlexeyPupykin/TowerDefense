using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class WaveSpawner : MonoBehaviour
{
    private float countdown = 2f;
    private int waveIndex = 0;

    public float timeBetweenWaves = 5f;
    public float ratioBetweenEnemies = 7.0f;
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
            waveCounterText.text = "wave " + PlayerStats.Rounds.ToString();
        else
            waveCounterText.text = PlayerStats.Rounds.ToString() + "/" + PlayerStats.Waves.ToString() + " waves";
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
                var enemy = enemies.Find(e => e == currentCustomWave.enemy);
                SpawnEnemy(enemy.prefab);
                yield return new WaitForSeconds(ratioBetweenEnemies / enemy.startSpeed);
            }
        }
        else
        {
            for (int i = 0; i < waveIndex; i++)
            {
                Enemy enemy;
                var rnd = new System.Random();
                enemy = enemies[rnd.Next(enemies.Count)];

                //if (waveIndex % 10 == 0)
                //    enemy = enemies.Find(e => e.type == EnemyType.Fat);
                //else if (waveIndex % 5 == 0)
                //    enemy = enemies.Find(e => e.type == EnemyType.Fast);
                //else
                //    enemy = enemies.Find(e => e.type == EnemyType.Standart);

                SpawnEnemy(enemy.prefab);
                yield return new WaitForSeconds(ratioBetweenEnemies / enemy.startSpeed);
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
    public Enemy enemy;
}
