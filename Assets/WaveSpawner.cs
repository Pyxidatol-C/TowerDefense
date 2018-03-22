using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnPoint;

    public float TimeBetweenWaves = 5.5f;
    public Text WaveCountdownText;
    private float _countdown = 2f;

    private int _waveIndex;

    private void Update()
    {
        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Round(_countdown).ToString(CultureInfo.InvariantCulture);
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (var i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}