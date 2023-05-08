using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class BaseEnemyBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Should be a GameObject with children where each child is a point that the enemy will travel to. " +
             "The enemy travels in straight lines to each point. The enemy will stop and do nothing once it reaches the last point.")]
    private GameObject travelPath;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private float maxHealth;

    private List<Transform> pathNodes;
    protected Vector3 nextDestination;
    private int nextDestinationIndex;
    private float currentHealth;

    protected const float CLOSE_ENOUGH = 0.2f;

    // Use this callback if something needs to know when this enemy died
    public Action<BaseEnemyBehavior> onEnemyDeathCallback;

    protected virtual void Start()
    {
        pathNodes = new List<Transform>();
        foreach (Transform childTransform in travelPath.transform)
        {
            pathNodes.Add(childTransform);
        }
        nextDestination = pathNodes[0].position;
        nextDestinationIndex = 0;

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if ((transform.position - nextDestination).magnitude <= CLOSE_ENOUGH)
        {
            nextDestinationIndex++;
            if (nextDestinationIndex < pathNodes.Count)
            {
                nextDestination = pathNodes[nextDestinationIndex].position;
            }
        }

        MoveToNextNode();
    }

    protected virtual void MoveToNextNode()
    {
        transform.position += Vector3.Normalize(nextDestination - transform.position) * speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (onEnemyDeathCallback != null) onEnemyDeathCallback(this);
            Destroy(gameObject);
        }
    }
}
