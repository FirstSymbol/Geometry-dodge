using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
  public class EnemyShooting : MonoBehaviour
  {
    [SerializeField] private EnemyProjectile  projectilePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Transform projectilesContainer;
    public void Shoot()
    {
      EnemyProjectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, projectilesContainer);
      projectile.Launch().Forget();
    }
  }
}