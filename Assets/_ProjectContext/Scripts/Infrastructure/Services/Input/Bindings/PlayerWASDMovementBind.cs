using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input.Bindings
{
  public class PlayerWASDMovementBind : InputBind<PlayerMovement>
  {
    protected override HashSet<PlayerMovement> BindedInstances { get; set; }
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
      foreach (PlayerMovement playerMovement in BindedInstances)
      {
        playerMovement.velocity = obj.ReadValue<Vector2>(); 
      }
    }
  }
}