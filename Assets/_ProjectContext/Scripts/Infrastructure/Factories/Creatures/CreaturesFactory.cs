using System;
using Gameplay;
using Infrastructure.Configs.Providers;
using Infrastructure.Observers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories.Creatures
{
  public class CreaturesFactory
  {
    public FactorySpawnObjectObserver<Player> playerObserver = new ();
    private CreaturesProvider _creaturesProvider;
    public CreaturesFactory()
    {
      
    }

    public GameObject SpawnTriangleEnemy()
    {
      return null;
    }
    
    public Player SpawnPlayer(Vector3 position, Quaternion rotation, Transform parent)
    {
      Player player = Object.Instantiate<Player>(_creaturesProvider.playerPrefab, position, rotation, parent);
      playerObserver.onItemCreated.Invoke(player);
      return player;
    }
  }
}