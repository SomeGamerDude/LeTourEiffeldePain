using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField]
    private GameObject ProjectileSpawner;

    private Transform targetPos;
    public float range = 10f;
    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindEnemyTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos == null)
        {
            return;
        }
        else
        {
            LockOnToEnemy();
        }
    }

    void FindEnemyTarget()
    {
        GameObject[] enemyTargets = GameObject.FindGameObjectsWithTag(enemyTag);
        float proxDistance = Mathf.Infinity;
        GameObject nearestTarget = null;
        foreach (GameObject enemy in enemyTargets)
        {
            float targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
            if (targetDistance < proxDistance)
            {
                proxDistance = targetDistance;
                nearestTarget = enemy;
            }
        }

        if (nearestTarget != null && proxDistance <= range)
        {
            targetPos = nearestTarget.transform;
        }
        else
        {
            targetPos = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void LockOnToEnemy()
    {
        Vector3 towerRotation = targetPos.transform.position - transform.position;
        float rotationAngle = Vector3.SignedAngle(transform.up, towerRotation, transform.forward);
        transform.Rotate(0f, 0f, rotationAngle);
    }

}
