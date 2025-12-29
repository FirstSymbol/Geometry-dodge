using Infrastructure.Services.Input;
using WindowsSystem;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectServicesInstaller : MonoInstaller
  {
    override public void InstallBindings()
    {
      Container.BindInterfacesTo<WindowsService>().FromNew().AsSingle().NonLazy();
      Container.BindInterfacesTo<InputService>().FromNew().AsSingle().NonLazy();
      Container.BindInterfacesTo<InputBindingService>().FromNew().AsSingle().NonLazy();
    }
  }
}