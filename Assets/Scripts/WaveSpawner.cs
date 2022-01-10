using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemyFastPrefab;
    public Transform enemyFatPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;
    private float countdown = 2f;

    public Text waveCounterText;

    private int waveIndex = 0;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCounterText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            if (waveIndex % 10 == 0)
            {
                SpawnEnemy(enemyFatPrefab);
            }
            else if (waveIndex % 5 == 0)
            {
                SpawnEnemy(enemyFastPrefab);
            }
            else
            {
                SpawnEnemy(enemyPrefab);
            }
            
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
