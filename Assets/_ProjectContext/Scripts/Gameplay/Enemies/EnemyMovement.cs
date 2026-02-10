using System;
using UnityEngine;

namespace Gameplay
{
  public class EnemyMovement : MonoBehaviour
  {
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float distanceToStop;
    [SerializeField] private bool displayRadius;

    public float GetDistance()
      => Vector3.Distance(transform.position, target.position);
    
    public void Move()
    {
      var needStop = GetDistance() <= distanceToStop;

      Vector2 direction = target.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
      
      
      transform.rotation = Quaternion.Euler(0f, 0f, angle);
      if (!needStop) 
        transform.position += transform.up * (speed * Time.deltaTime);
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