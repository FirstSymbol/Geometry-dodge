using System;
using Gameplay.Creatures;
using LitMotion;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameplay.UI
{
  public class HealthBarController : MonoBehaviour
  {
    public CreatureHealth creatureHealth;
    public RectMask2D rectMask;
    public float sliderValue = 1.38f;
    private void OnEnable()
    {
      creatureHealth.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
      creatureHealth.OnTakeDamage -= TakeDamage;
    }

    private void Start()
    {
      UpdateHealth(0f);
    }

    private void TakeDamage()
    {
      UpdateHealth(0.2f);
    }

    private void UpdateHealth(float duration)
    {
      var t = (float)creatureHealth.HealthValue / creatureHealth.MaxHealthValue;
      LMotion.Create(rectMask.padding.z, sliderValue - (sliderValue * t), duration)
        .Bind(v => rectMask.padding = new Vector4(0, 0, v));

    }
  }
}