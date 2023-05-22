using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Wave", menuName = "Scriptable Objects/Enemy Waves", order = 0)]
public class EnemyWave : ScriptableObject
{
    [Tooltip("Time between individual enemy spawns.")]
    public float individualSpawnDelay = 0.3f;
    [Tooltip("Time between this and next wave.")]
    public float delayUntilNextWave = 2.0f;
    public BaseEnemyBehavior[] enemies;
}
