using UnityEngine;

namespace Gameplay
{
  public class PlayerMovementGraphic : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer playerInSprite;
    [SerializeField] private float playerInRadius;
    [SerializeField] private bool displayPlayerInRadius;
    [SerializeField] private Transform playerTransform;
    
    public void SetGraphic(in Vector2 move)
    {
       playerInSprite.gameObject.transform.localPosition = move * playerInRadius;
    }

    private void OnDrawGizmos()
    {
      if (displayPlayerInRadius)
      {
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireSphere(playerTransform.position, playerInRadius);
      }
    }
  }
}