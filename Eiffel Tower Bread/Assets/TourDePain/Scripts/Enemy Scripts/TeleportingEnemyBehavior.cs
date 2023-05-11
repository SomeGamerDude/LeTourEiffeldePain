using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingEnemyBehavior : BaseEnemyBehavior
{
    [SerializeField]
    [Tooltip("This determines cooldown. Speed determines distance teleported. Always stops at nodes")]
    private float teleportCooldownSeconds;

    private bool onCooldown;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(TeleportCooldownHandler());
    }

    protected override void MoveToNextNode()
    {
        if (!onCooldown)
        {
            Vector3 transformShift = Vector3.Normalize(nextDestination - transform.position) * speed;

            // Make sure we don't go past the next node 
            if (Vector3.Distance(transform.position, transform.position + transformShift) >
                Vector3.Distance(transform.position, nextDestination))
            {
                transform.position = nextDestination;
            }
            else
            {
                transform.position += transformShift;
            }

            StartCoroutine(TeleportCooldownHandler());
        }
    }

    private IEnumerator TeleportCooldownHandler()
    {
        onCooldown = true;
        yield return new WaitForSeconds(teleportCooldownSeconds);
        onCooldown = false;
    }
}
