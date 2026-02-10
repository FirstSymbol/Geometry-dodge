using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Configs;

namespace Infrastructure.StateMachines.States
{
  public class GameloopState : BaseGameplayState
  {
    private readonly IScenesProvider _sceneProvider;
    private readonly IInputBindingService _bindingService;
    
    private  PlayerInteractionBind _playerInteractionBind;
    private  PlayerWASDMovementBind _playerWASDMovementBind;
    private  PlayerDashMovementBind _playerDashMovementBind;

    public GameloopState(IInputBindingService bindingService, IScenesProvider sceneProvider, GameplayStateMachine stateMachine) : base(stateMachine)
    {
      _bindingService = bindingService;
      _sceneProvider = sceneProvider;
    }

    public override UniTask Exit()
    {
      _playerInteractionBind?.UnBind(); 
      _playerWASDMovementBind?.UnBind();
      _playerDashMovementBind?.UnBind();
      return default;
    }

    public override async UniTask Enter()
    {
      _playerInteractionBind ??= _bindingService.GetBind<PlayerInteractionBind>();
      _playerWASDMovementBind ??= _bindingService.GetBind<PlayerWASDMovementBind>();
      _playerDashMovementBind ??= _bindingService.GetBind<PlayerDashMovementBind>();
      
      _playerInteractionBind?.Bind();
      _playerWASDMovementBind?.Bind();
      _playerDashMovementBind?.Bind();

      await _sceneProvider.Gameloop.LoadSceneAsync();
    }
  }
}