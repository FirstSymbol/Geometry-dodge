using UnityEngine.AddressableAssets;

namespace Scripts.Configs
{
  public interface IScenesProvider
  {
    AssetReference EntryPoint { get; }
    AssetReference MainMenu { get; }
    AssetReference Gameloop { get; }
  }
}