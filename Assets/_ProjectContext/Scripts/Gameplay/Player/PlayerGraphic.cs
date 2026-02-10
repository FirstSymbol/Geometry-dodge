using System;
using UnityEngine;

namespace Gameplay.Player
{
  public class PlayerGraphic : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer playerInSprite;
    [SerializeField] private float playerInRadius;
    [SerializeField] private bool displayPlayerInRadius;
    [SerializeField] private Transform playerTransform;
    public void SetMoveGraphic(in Vector2 move)
    {
       
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