using Cysharp.Threading.Tasks;
using Scripts.Configs;

namespace Infrastructure.StateMachines.States
{
  public class GameloopState : BaseGameplayState
  {
    IScenesProvider _sceneProvider;
    public GameloopState(IScenesProvider sceneProvider, GameplayStateMachine stateMachine) : base(stateMachine)
    {
      _sceneProvider = sceneProvider;
    }

    public override UniTask Exit()
    {
      return default;
    }

    public override async UniTask Enter()
    {
      await _sceneProvider.Gameloop.LoadSceneAsync();
    }
  }
}