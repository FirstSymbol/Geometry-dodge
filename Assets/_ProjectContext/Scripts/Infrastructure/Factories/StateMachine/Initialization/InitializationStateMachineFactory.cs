using ExtDebugLogger;
using JetBrains.Annotations;
using Scripts.Infrastructure.Factories.StateMachines.GameLoop;
using Infrastructure.StateMachines;
using Zenject;

namespace Scripts.Infrastructure.Factories.StateMachine
{
  [UsedImplicitly]
  public class InitializationStateMachineFactory : IInitializationStateMachineFactory
  {
    private InitializationStateMachine _stateMachine;
    private readonly IInstantiator _instantiator;

    [Inject]
    public InitializationStateMachineFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public InitializationStateMachine GetFrom(object summoner)
    {
      _stateMachine ??= _instantiator.Instantiate<InitializationStateMachine>();
      Logger.Log($"Access to the {nameof(InitializationStateMachine)} is obtained from {summoner}", StateMachineLogTag.InitializationStateMachine);
      return _stateMachine;
    }
  }
}