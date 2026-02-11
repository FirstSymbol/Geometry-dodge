using System;
using System.Security.Permissions;
using ExtInspectorTools;
using Gameplay.Creatures;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Infrastructure.Entry;
using UnityEngine;
using Zenject;
using Logger = ExtDebugLogger.Logger;

namespace Gameplay
{
  public class Player : MonoBehaviour, ICreature
  {
    [Inject] private IInputBindingService inputBindingService;
    public PlayerMovement playerMovement;
    [SerializeField] private CreatureHealth health;
    public CreatureHealth Health => health;
    
    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;
      health.OnDeath += Death;
    }

    private void OnDisable()
    {
      if (!EntryPoint.Initialized)
        return;
      health.OnDeath -= Death;
    }

    private void Death()
    {
      Destroy(gameObject);
    }
  }
}