using Gameplay;
using Gameplay.Body;
using UnityEngine;

namespace Infrastructure.Configs.Providers
{
  [CreateAssetMenu(fileName = "CreaturesProvider config", menuName = "Configs/Providers/Creatures", order = 0)]
  public class CreaturesProvider : ScriptableObject
  {
    public Player playerPrefab;
    public TriangleEnemy triangleEnemy;
  }
}