using Cysharp.Threading.Tasks;
using ExtState;
using Zenject;

namespace Infrastructure.StateMachines
{
  public abstract class BaseGameplayState : IState, IEnterableState
  {
    GameplayStateMachine stateMachine;
    [Inject]
    public BaseGameplayState(GameplayStateMachine stateMachine) => 
      this.stateMachine = stateMachine;

    public abstract UniTask Exit();

    public abstract UniTask Enter();
  }
}