using Infrastructure.Services.Input;
using Infrastructure.Services.Input;
using WindowsSystem;
using WindowsSystem.Resolver;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectServicesInstaller : MonoInstaller
  {
    override public void InstallBindings()
    {
      Container.BindInterfacesTo<WindowsService>().FromMethod( ctx =>
      {
        var resolver = new DependencyResolver(Container.Resolve);
        return new WindowsService(resolver);
      }).AsSingle().NonLazy();
      Container.BindInterfacesTo<InputService>().FromNew().AsSingle().NonLazy();
      Container.BindInterfacesTo<InputBindingService>().FromNew().AsSingle().NonLazy();
    }
  }
}