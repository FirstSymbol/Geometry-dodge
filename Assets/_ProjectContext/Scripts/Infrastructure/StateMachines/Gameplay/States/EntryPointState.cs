using Cysharp.Threading.Tasks;
using ExtDebugLogger;
using Infrastructure.Factories.StateMachines;

namespace Infrastructure.StateMachines.States
{
  public class EntryPointState : BaseGameplayState
  {
    private IStateMachineFactory<InitializationStateMachine> _initializationStateMachineFactory;
    
    public EntryPointState(IStateMachineFactory<InitializationStateMachine> initializationStateMachineFactory,
      GameplayStateMachine stateMachine) : base(stateMachine)
    {
      _initializationStateMachineFactory = initializationStateMachineFactory;
    }

    public override UniTask Exit()
    {
      return default;
    }

    public override async UniTask Enter()
    {
      await _initializationStateMachineFactory.GetFrom(this).NextState();
    }
  }
}