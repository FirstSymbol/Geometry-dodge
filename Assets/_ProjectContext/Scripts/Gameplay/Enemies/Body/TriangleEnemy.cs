using Gameplay.Movement;
using Gameplay.Shooting;
using UnityEngine;

namespace Gameplay.Body
{
  [RequireComponent(typeof(DefaultEnemyMovement))]
  [RequireComponent(typeof(DefaultEnemyShooting),typeof(TriangleEnemyAI))]
  public class TriangleEnemy : MonoBehaviour
  {
    [SerializeField] private TriangleEnemyAI triangleEnemyAI;
    [SerializeField] private DefaultEnemyMovement enemyMovement;
    [SerializeField] private DefaultEnemyShooting defaultEnemyShooting;
    
    
  }
}