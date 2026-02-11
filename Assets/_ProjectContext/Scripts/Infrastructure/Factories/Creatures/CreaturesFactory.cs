using System;
using Gameplay;
using Gameplay.Body;
using Infrastructure.Configs.Providers;
using Infrastructure.Observers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories.Creatures
{
  public class CreaturesFactory
  {
    public SingleSpawnObjectObserver<Player> playerObserver = new ();
    public event Action<TriangleEnemy> onTriangleEnemySpawned;
    private CreaturesProvider _creaturesProvider;
    public CreaturesFactory()
    {
      
    }
    
    public TriangleEnemy SpawnTriangleEnemy(Vector3 position, Quaternion rotation, Transform parent)
    {
      TriangleEnemy enemy = Object.Instantiate<TriangleEnemy>(_creaturesProvider.triangleEnemy, position, rotation, parent);
      onTriangleEnemySpawned?.Invoke(enemy);
      return enemy;
    }
    
    public Player SpawnPlayer(Vector3 position, Quaternion rotation, Transform parent)
    {
      Player player = Object.Instantiate<Player>(_creaturesProvider.playerPrefab, position, rotation, parent);
      playerObserver.onItemCreated?.Invoke(player);
      return player;
    }
  }
}