using UnityEngine;

namespace Gameplay.Player
{
  public class Movement : MonoBehaviour
  {
    public Vector2 velocity;
    public float speed;

    private void Move()
    {
      velocity.Normalize();
      if (velocity.magnitude <= 0)
        return;
      
      transform.Translate(velocity * speed * Time.deltaTime);
    }
  }
}