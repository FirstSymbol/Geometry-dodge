using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Configs
{
  [CreateAssetMenu(fileName = "ScenesProvider Config", menuName = "Configs/Providers/Scenes", order = 0)]
  public class ScenesProvider : ScriptableObject, IScenesProvider
  {
    [field: SerializeField] public AssetReference EntryPoint { get; private set; }
    [field: SerializeField] public AssetReference MainMenu { get; private set; }
    [field: SerializeField] public AssetReference Gameloop { get; private set; }
  }
}