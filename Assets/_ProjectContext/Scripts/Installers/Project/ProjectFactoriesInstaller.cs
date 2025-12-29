using ExtState.Factories;
using Infrastructure.Factories.StateMachines;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectFactoriesInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesTo<StatesFactory>().FromNew().AsSingle().NonLazy();
      Container.BindInterfacesTo<InitializationStateMachineFactory>().FromNew().AsSingle().NonLazy();
      Container.BindInterfacesTo<GameplayStateMachineFactory>().FromNew().AsSingle().NonLazy();
    }
  }
}