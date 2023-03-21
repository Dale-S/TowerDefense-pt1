using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownText;
    public float timeBetweenWaves = 20f;
    
    private float countdown = 10f;
    private int waveNumber = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //waveCountdownText.text = "Next Wave: " + Mathf.Ceil(countdown).ToString();
        waveCountdownText.text = "Next Wave: " + string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Wave Incoming");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
