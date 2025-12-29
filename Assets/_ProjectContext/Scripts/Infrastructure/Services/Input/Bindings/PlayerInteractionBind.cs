using System.Collections.Generic;
using ExtDebugLogger;
using Gameplay.Player;
using ModestTree;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input.Bindings
{
  public class PlayerInteractionBind : InputBind<Player>
  {
    protected override HashSet<Player> BindedInstances { get; set; }
    private GameInput _gameInput;
    
    public PlayerInteractionBind(IInputService inputService) : base(inputService)
    {
      _gameInput = inputService.GetInput<GameInput>();
    }
    
    protected override void BindAction()
    {
      _gameInput.Player.Interact.started += InteractOnstarted;
    }

    protected override void UnbindAction()
    {
      _gameInput.Player.Interact.started -= InteractOnstarted;
    }

    private void InteractOnstarted(InputAction.CallbackContext obj)
    {
      foreach (var player in BindedInstances)
      {
        player.Test();
      }
    }
  }
}