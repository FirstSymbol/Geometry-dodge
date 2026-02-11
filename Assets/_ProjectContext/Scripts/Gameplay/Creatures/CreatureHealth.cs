using System;
using UnityEngine;

namespace Gameplay.Creatures
{
  public class CreatureHealth : MonoBehaviour
  {
    [SerializeField] private int maxHealthValue = 100;
    [SerializeField] private int healthValue = 100;
    public int HealthValue => healthValue;
    public int MaxHealthValue => maxHealthValue;
    public event Action OnDeath;
    public event Action OnTakeDamage;

    public void Damage(int amount)
    {
      healthValue -= amount;
      OnTakeDamage?.Invoke();
      if (healthValue <= 0)
      {
        OnDeath?.Invoke();
      }
    }
  }
}