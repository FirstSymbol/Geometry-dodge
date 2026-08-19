using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Shooting
{
  public class DefaultEnemyShooting : MonoBehaviour
  {
    [SerializeField] private EnemyProjectile  projectilePrefab;
    [SerializeField] private Transform rotationReference;
    [SerializeField] private Transform target;
    [SerializeField] private Transform projectilesContainer;
    public void Shoot()
    {
      EnemyProjectile projectile = Instantiate(projectilePrefab, transform.position, rotationReference.rotation, projectilesContainer);
      projectile.Launch().Forget();
    }
  }
}