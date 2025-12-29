using System;
using ExtInspectorTools;
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
    [SerializeField] private SerializableType<IInputBindBase> interactionBindType;
    private IInputBindBase interactionBind;

    private void OnEnable()
    {
      interactionBind ??= inputBindingService.GetBind(interactionBindType.Type);
      
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