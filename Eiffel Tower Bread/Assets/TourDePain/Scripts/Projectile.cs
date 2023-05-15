using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float projSpeed = 10f;
    [SerializeField]
    private float projDamage = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 pathDir = target.position - transform.position;
        float disToTravel = projSpeed * Time.deltaTime;

        if (pathDir.magnitude <= disToTravel)
        {
            HitTarget();
            return;
        }
        else
        {
            transform.Translate(pathDir.normalized * disToTravel, Space.World);
        }

    }

    public void Seek (Transform targetPosition)
    {
        target = targetPosition;
    }

    void HitTarget()
    {
        Destroy(gameObject);
        BaseEnemyBehavior enemyTarget = target.GetComponent<BaseEnemyBehavior>();

        if (enemyTarget != null)
        {
        enemyTarget.TakeDamage(projDamage);
        }
    }

}
