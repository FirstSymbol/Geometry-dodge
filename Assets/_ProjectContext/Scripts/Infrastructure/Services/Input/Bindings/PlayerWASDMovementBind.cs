using System;
using System.Collections.Generic;
using Gameplay;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input.Bindings
{
  public class PlayerWASDMovementBind : InputBind<Action<float2>>
  {
    protected override HashSet<Action<float2>> BindedInstances { get; set; }
    private GameInput _gameInput;
    private bool _pressed;
    
    public PlayerWASDMovementBind(IInputService inputService) : base(inputService)
    {
      _gameInput = inputService.GetInput<GameInput>();
    }

    protected override void BindAction()
    {
      _gameInput.Player.Move.canceled += Move;
      _gameInput.Player.Move.performed += Move;
    }

    protected override void UnbindAction()
    {
      _gameInput.Player.Move.performed -= Move;
      _gameInput.Player.Move.canceled -= Move;
    }
    private void Move(InputAction.CallbackContext obj)
    {
      foreach (var instance in BindedInstances)
      {
        instance.Invoke(obj.ReadValue<Vector2>());
      }
    }
  }
}