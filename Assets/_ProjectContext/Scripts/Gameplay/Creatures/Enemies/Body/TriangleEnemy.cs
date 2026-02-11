using System;
using Gameplay.Creatures;
using Gameplay.Movement;
using Gameplay.Shooting;
using Scripts.Infrastructure.Entry;
using UnityEngine;

namespace Gameplay.Body
{
  [RequireComponent(typeof(DefaultEnemyMovement))]
  [RequireComponent(typeof(DefaultEnemyShooting),typeof(TriangleEnemyAI))]
  public class TriangleEnemy : MonoBehaviour, ICreature
  {
    [SerializeField] private TriangleEnemyAI triangleEnemyAI;
    [SerializeField] private DefaultEnemyMovement enemyMovement;
    [SerializeField] private DefaultEnemyShooting defaultEnemyShooting;
    [SerializeField] private CreatureHealth health;
    public CreatureHealth Health => health;

    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;
      health.OnDeath += Death;
    }

    private void OnDisable()
    {
      if (!EntryPoint.Initialized)
        return;
      health.OnDeath -= Death;
    }

    private void Death()
    {
      Destroy(gameObject);
    }
  }
}