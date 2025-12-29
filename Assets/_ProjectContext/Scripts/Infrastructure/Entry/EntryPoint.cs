using System;
using Infrastructure.Factories.StateMachines;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.States;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Entry
{
  public class EntryPoint : MonoBehaviour
  {
    public static bool Initialized;

    [Inject] private IStateMachineFactory<GameplayStateMachine> _gameplayStateMachineFactory;
    
    private void Awake()
    {
      Initialized = true;
    }

    private void Start()
    {
      GameplayStateMachine stateMachine = _gameplayStateMachineFactory.GetFrom(this);
      stateMachine.Enter<EntryPointState>();
    }
  }
}