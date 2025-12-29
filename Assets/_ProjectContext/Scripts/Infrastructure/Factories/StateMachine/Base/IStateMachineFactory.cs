using ExtState;

namespace Infrastructure.Factories.StateMachines
{
    public interface IStateMachineFactory<T> where T : BaseStateMachine
    {
        T GetFrom(object summoner);
    }
}