using System;
using ExtState;
using ExtState.Factories;
using Infrastructure.StateMachines.States;
using Zenject;

namespace Infrastructure.StateMachines
{
  public class InitializationStateMachine : SequentialStateMachine
  {
    public override Enum LogTag => StateMachineLogTag.InitializationStateMachine;

    [Inject]
    public InitializationStateMachine(IStatesFactory statesFactory) : base()
    {
      RegisterState(statesFactory.Create<InitializationInputServiceState>(this));
      RegisterState(statesFactory.Create<InitializationFinalizerState>(this));
    }
  }
}