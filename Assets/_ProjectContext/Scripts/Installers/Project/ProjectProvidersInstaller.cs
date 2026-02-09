using Scripts.Configs;
using UnityEngine;
using WindowsSystem.Providers;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectProvidersInstaller : MonoInstaller
  {
    [SerializeField] private ScenesProvider scenesProvider;
    [SerializeField] private WindowsProvider windowsProvider;
    public override void InstallBindings()
    {
      Container.Bind<IScenesProvider>().To<ScenesProvider>().FromInstance(scenesProvider).AsSingle().NonLazy();
      Container.Bind<IWindowsProvider>().To<WindowsProvider>().FromInstance(windowsProvider).AsSingle().NonLazy();
    }
  }
}