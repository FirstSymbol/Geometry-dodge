using Cysharp.Threading.Tasks;
using ExtDebugLogger;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;

namespace Infrastructure.StateMachines.States
{
  public class InitializationInputServiceState : BaseInitializationState
  {
    private IInputService _inputService;
    private IInputBindingService _inputBindingService;
    
    public InitializationInputServiceState(IInputService inputService, IInputBindingService inputBindingService, InitializationStateMachine stateMachine) : base(stateMachine)
    {
      _inputService = inputService;
      _inputBindingService = inputBindingService;
    }

    public override UniTask Exit()
    {
      return UniTask.CompletedTask;
    }

    public override UniTask Enter()
    {
      var gameInput = new GameInput();
      // InputService
      _inputService.AddInput(gameInput);
      
      // InputBindingService
      _inputBindingService.AddBinding<PlayerWASDMovementBind>();
      _inputBindingService.AddBinding<PlayerDashMovementBind>();
      _inputBindingService.AddBinding<PlayerShootBind>();
      
      gameInput.Enable();
      
      stateMachine.NextState();
      return UniTask.CompletedTask;
    }
  }
}