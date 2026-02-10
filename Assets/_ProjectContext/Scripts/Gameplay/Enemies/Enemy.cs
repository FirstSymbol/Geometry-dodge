using UnityEngine;

namespace Gameplay
{
  public class Enemy : MonoBehaviour
  {
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooting enemyShooting;
    
    
  }
}