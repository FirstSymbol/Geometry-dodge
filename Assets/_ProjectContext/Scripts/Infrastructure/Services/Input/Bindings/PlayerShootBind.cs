using System.Collections.Generic;
using ExtDebugLogger;
using Gameplay;
using ModestTree;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input.Bindings
{
  public class PlayerShootBind : InputBind<PlayerShoot>
  {
    protected override HashSet<PlayerShoot> BindedInstances { get; set; }
    private GameInput _gameInput;
    
    public PlayerShootBind(IInputService inputService) : base(inputService)
    {
      _gameInput = inputService.GetInput<GameInput>();
    }
    
    protected override void BindAction()
    {
      _gameInput.Player.Attack.started += ShootingStarted;
    }

    protected override void UnbindAction()
    {
      _gameInput.Player.Attack.started -= ShootingStarted;
    }

    private void ShootingStarted(InputAction.CallbackContext obj)
    {
      foreach (PlayerShoot playerShoot in BindedInstances)
      {
        playerShoot.ShootDefault();
      }
    }
  }
}