using JetBrains.Annotations;
using Infrastructure.StateMachines;
using Zenject;

namespace Infrastructure.Factories.StateMachines
{
    [UsedImplicitly]
    public class GameplayStateMachineFactory : BaseStateMachineFactory<GameplayStateMachine>
    {
        public GameplayStateMachineFactory(IInstantiator instantiator) : base(instantiator)
        {
        }   
    }
}