using Cysharp.Threading.Tasks;
using ExtState;
using Zenject;

namespace Infrastructure.StateMachines
{
  public abstract class BaseInitializationState : IState, IEnterableState
  {
    InitializationStateMachine stateMachine;
    [Inject]
    public BaseInitializationState(InitializationStateMachine stateMachine) => 
      this.stateMachine = stateMachine;

    public abstract UniTask Exit();

    public abstract UniTask Enter();
  }
}