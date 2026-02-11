using System;
using System.Security.Permissions;
using ExtInspectorTools;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Infrastructure.Entry;
using UnityEngine;
using Zenject;
using Logger = ExtDebugLogger.Logger;

namespace Gameplay
{
  public class Player : MonoBehaviour
  {
    [Inject] private IInputBindingService inputBindingService;
    
    public PlayerMovement playerMovement;
    
    public void Test()
    {
      Logger.Log("Test");
    }
  }
}