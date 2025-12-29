using JetBrains.Annotations;
using Infrastructure.StateMachines;
using Zenject;

namespace Infrastructure.Factories.StateMachines
{
    [UsedImplicitly]
    public class InitializationStateMachineFactory : BaseStateMachineFactory<InitializationStateMachine>
    {
        public InitializationStateMachineFactory(IInstantiator instantiator) : base(instantiator)
        {
        }   
    }
}