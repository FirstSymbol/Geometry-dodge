using Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Scripts.Installers
{
  public class ProjectProvidersInstaller : MonoInstaller
  {
    [SerializeField] private ScenesProvider scenesProvider;
    public override void InstallBindings()
    {
      Container.Bind<IScenesProvider>().To<ScenesProvider>().FromInstance(scenesProvider).AsSingle().NonLazy();
    }
  }
}