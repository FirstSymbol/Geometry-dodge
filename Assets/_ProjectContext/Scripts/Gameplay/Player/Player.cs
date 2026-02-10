using System;
using System.Security.Permissions;
using ExtInspectorTools;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Infrastructure.Entry;
using UnityEngine;
using Zenject;
using Logger = ExtDebugLogger.Logger;

namespace Gameplay.Player
{
  public class Player : MonoBehaviour
  {
    [Inject] private IInputBindingService inputBindingService;
    
    public PlayerMovement playerMovement;
    
    private PlayerInteractionBind interactionBind;

    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;
      interactionBind ??= inputBindingService.GetBind<PlayerInteractionBind>();
      
      interactionBind?.AddBindingInstance(this);
    }

    private void OnDisable()
    {
      interactionBind?.RemoveBindingInstance(this);
    }

    
    public void Test()
    {
      Logger.Log("Test");
    }
  }
}