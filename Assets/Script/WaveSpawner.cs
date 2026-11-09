using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    public float spawnWaveInterval = 5f;
    public float spawnEnemyInterval = 0.5f;
    private float countdown = 5f;
    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = spawnWaveInterval;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.CeilToInt(countdown).ToString();
    }

    IEnumerator SpawnWave() 
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        { 
            SpawnEnemy();
            yield return new WaitForSeconds(spawnEnemyInterval);
        }  


    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
