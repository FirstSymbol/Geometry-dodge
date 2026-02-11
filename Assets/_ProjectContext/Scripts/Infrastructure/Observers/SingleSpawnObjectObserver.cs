using System;
using UnityEngine;

namespace Infrastructure.Observers
{
  public class SingleSpawnObjectObserver<T>
  {
    public Action<T> onItemCreated;
    public bool isSpawned = false;
    public T item;
  }
}