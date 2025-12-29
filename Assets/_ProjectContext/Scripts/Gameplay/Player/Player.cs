using System;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using UnityEngine;
using Zenject;
using Logger = ExtDebugLogger.Logger;

namespace Gameplay.Player
{
  public class Player : MonoBehaviour
  {
    [Inject] private IInputBindingService inputBindingService;
    private PlayerInteractionBind interactionBind;

    private void OnEnable()
    {
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