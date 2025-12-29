using Cysharp.Threading.Tasks;
using Infrastructure.Factories.StateMachines;

namespace Infrastructure.StateMachines.States
{
  public class InitializationFinalizerState : BaseInitializationState
  {
    private IStateMachineFactory<GameplayStateMachine> _stateMachineFactory;
    
    public InitializationFinalizerState(IStateMachineFactory<GameplayStateMachine> stateMachineFactory, InitializationStateMachine stateMachine) : base(stateMachine)
    {
      _stateMachineFactory = stateMachineFactory;
    }

    public override UniTask Exit()
    {
      return UniTask.CompletedTask;
    }

    public override UniTask Enter()
    {
      var stateMachine = _stateMachineFactory.GetFrom(this);
      stateMachine.Enter<GameloopState>();
      return UniTask.CompletedTask;
    }
  }
}