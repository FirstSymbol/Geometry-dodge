using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input.Bindings
{
  public class PlayerDashMovementBind : InputBind<PlayerMovement>
  {
    protected override HashSet<PlayerMovement> BindedInstances { get; set; }
    private GameInput _gameInput;
    private bool _pressed;
    
    public PlayerDashMovementBind(IInputService inputService) : base(inputService)
    {
      _gameInput = inputService.GetInput<GameInput>();
    }

    protected override void BindAction()
    {
      _gameInput.Player.Dash.started += Dash;
    }

    protected override void UnbindAction()
    {
      _gameInput.Player.Dash.started -= Dash;
    }
    private void Dash(InputAction.CallbackContext obj)
    {
      foreach (PlayerMovement playerMovement in BindedInstances)
      {
        playerMovement.Dash();
      }
    }
  }
}