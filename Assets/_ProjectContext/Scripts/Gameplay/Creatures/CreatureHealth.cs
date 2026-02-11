using System;
using UnityEngine;

namespace Gameplay.Creatures
{
  public class CreatureHealth : MonoBehaviour
  {
    [SerializeField] private int healthValue = 100;
    public int HealthValue => healthValue;
    public event Action OnDeath;

    public void Damage(int amount)
    {
      healthValue -= amount;
      if (healthValue <= 0)
      {
        OnDeath?.Invoke();
      }
    }
  }
}