using WindowsSystem;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectServicesInstaller : MonoInstaller
  {
    override public void InstallBindings()
    {
      Container.BindInterfacesTo<WindowsService>().FromNew().AsSingle().NonLazy();
    }
  }
}