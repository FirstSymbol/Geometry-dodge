using UnityEngine;

namespace Gameplay.Movement
{
  public class DefaultEnemyMovement : MonoBehaviour
  {
    [SerializeField] private Transform target;
    [SerializeField] private Transform rotateRoot;
    [SerializeField] private Transform moveRoot;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float distanceToStop;
    [SerializeField] private bool displayRadius;

    public float GetDistance()
      => Vector3.Distance(transform.position, target.position);
    
    public void Move()
    {
      if (!target)
        return;
      var needStop = GetDistance() <= distanceToStop;

      Vector2 direction = target.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
      
      
      rotateRoot.rotation = Quaternion.Euler(0f, 0f, angle);
      Vector2 dir = (target.position - transform.position).normalized;
      if (!needStop) 
        moveRoot.position += new Vector3(dir.x * (speed * Time.deltaTime), dir.y * (speed * Time.deltaTime), moveRoot.position.z);
    }

    private void OnDrawGizmos()
    {
      if (displayRadius)
      {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToStop);
      }
    }
  }
}