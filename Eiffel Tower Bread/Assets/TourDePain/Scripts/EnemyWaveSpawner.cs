using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField]
    private float startDelay = 3.0f;
    [SerializeField]
    private GameObject travelPath;
    [SerializeField]
    private EnemyWave[] enemyWaves;

    private int currentWave;

    private void Start()
    {
        currentWave = 0;
        StartCoroutine(LaunchWaves());
    }

    private IEnumerator LaunchWaves()
    {
        yield return new WaitForSeconds(startDelay);

        for(; currentWave < enemyWaves.Length; currentWave++)
        {
            foreach (BaseEnemyBehavior enemy in enemyWaves[currentWave].enemies)
            {
                Debug.Log(transform.position.ToString());
                BaseEnemyBehavior newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                newEnemy.SetTravelPath(travelPath);
                yield return new WaitForSeconds(enemyWaves[currentWave].individualSpawnDelay);
            }
            yield return new WaitForSeconds(enemyWaves[currentWave].delayUntilNextWave);
        }
    }
}
