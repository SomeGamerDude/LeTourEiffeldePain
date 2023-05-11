using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab1; // prefab for enemy1
    [SerializeField]
    private GameObject enemyPrefab2; // prefab for enemy1
    [SerializeField]
    private GameObject enemyPrefab3; // prefab for enemy1

    [SerializeField]
    private float totalEnemies1;    // total number of enemy1
    [SerializeField]
    private float totalEnemies2;    // total number of enemy1
    [SerializeField]
    private float totalEnemies3;    // total number of enemy1
    [SerializeField]
    private float spawnTime;    // duration for spawning enemies
    [SerializeField]
    public Transform[] wayPoints;  // route for current stage


    private float totalEnemies;

    private void Awake()
    {
        totalEnemies = totalEnemies1 + totalEnemies2 + totalEnemies3;
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (totalEnemies > 0)
        {
            
            
            

            
            
            


            if (totalEnemies1 > 0)
            {
                GameObject clone1 = Instantiate(enemyPrefab1);
                BaseEnemyBehavior enemy1 = clone1.GetComponent<BaseEnemyBehavior>();
                enemy1.Setup();
                totalEnemies1--;
                totalEnemies--;
                yield return new WaitForSeconds(spawnTime);
            }
            else if (totalEnemies2 > 0)
            {
                GameObject clone2 = Instantiate(enemyPrefab2);
                BaseEnemyBehavior enemy2 = clone2.GetComponent<BaseEnemyBehavior>();
                enemy2.Setup();
                totalEnemies2--;
                totalEnemies--;
                yield return new WaitForSeconds(spawnTime);
            }
            else if (totalEnemies3 > 0)
            {
                GameObject clone3 = Instantiate(enemyPrefab3);
                BaseEnemyBehavior enemy3 = clone3.GetComponent<BaseEnemyBehavior>();
                enemy3.Setup();
                totalEnemies3--;
                totalEnemies--;
                yield return new WaitForSeconds(spawnTime);
            }




            //totalEnemies--;
            //yield return new WaitForSeconds(spawnTime);
        }
    }
}
