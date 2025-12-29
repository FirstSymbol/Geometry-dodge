using Infrastructure.StateMachines;

namespace Scripts.Infrastructure.Factories.StateMachines.GameLoop
{
    public interface IInitializationStateMachineFactory
    {
        InitializationStateMachine GetFrom(object summoner);
    }
}