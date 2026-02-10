using System;
using UnityEngine;

namespace Infrastructure.Observers
{
  public class FactorySpawnObjectObserver<T>
  {
    public Action<T> onItemCreated;
    public bool isSpawned = false;
    public T item;
  }
}