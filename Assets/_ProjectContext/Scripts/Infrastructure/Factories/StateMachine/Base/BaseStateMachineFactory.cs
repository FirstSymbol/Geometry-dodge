using ExtDebugLogger;
using ExtState;
using JetBrains.Annotations;
using Zenject;

namespace Infrastructure.Factories.StateMachines
{
    [UsedImplicitly]
    public abstract class BaseStateMachineFactory<T> : IStateMachineFactory<T> where T : BaseStateMachine
    {
        protected T _stateMachine;
        protected readonly IInstantiator _instantiator;

        [Inject]
        public BaseStateMachineFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public virtual T GetFrom(object summoner)
        {
            _stateMachine ??= _instantiator.Instantiate<T>();
            Logger.Log($"Access to the {nameof(T)} is obtained from {summoner}", _stateMachine.LogTag);
            return _stateMachine as T;
        }
    }
}