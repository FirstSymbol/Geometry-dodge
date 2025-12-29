using System;
using ExtState;
using ExtState.Factories;
using Infrastructure.StateMachines.States;
using Zenject;

namespace Infrastructure.StateMachines
{
  public class GameplayStateMachine : BaseStateMachine
  {
    public override Enum LogTag => StateMachineLogTag.GameplayStateMachine;
    
    [Inject]
    public GameplayStateMachine(IStatesFactory statesFactory)
    {
      RegisterState(statesFactory.Create<EntryPointState>(this));
      RegisterState(statesFactory.Create<MainMenuState>(this));
      RegisterState(statesFactory.Create<GameloopState>(this));
    }
  }
}