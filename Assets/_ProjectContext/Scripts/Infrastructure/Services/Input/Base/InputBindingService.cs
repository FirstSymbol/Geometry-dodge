using System;
using System.Collections.Generic;
using ExtDebugLogger;
using Zenject;

namespace Infrastructure.Services.Input
{
  public class InputBindingService : IInputBindingService
  {
    
    public Dictionary<Type, IInputBindBase> Binds = new();
    private readonly IInstantiator _instantiator;

    [Inject]
    public InputBindingService(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public bool AddBinding<T>() where T: class, IInputBindBase
    {
      if (Binds.ContainsKey(typeof(T))) return false;
      if (Binds.TryAdd(typeof(T), _instantiator.Instantiate<T>()))
        return true;
      Logger.Log($"Error when adding {typeof(T).Name} binding", InputServiceLogTag.InputBindings);
      return false;
    }

    public T GetBind<T>() where T : class, IInputBindBase => 
      Binds[(typeof(T))] as T;

    public bool TryGetBind<T>(out T bind) where T : class, IInputBindBase
    {
      bind = GetBind<T>();
      if (bind == null)
        return false;
      return true;
    }

    public IInputBindBase GetBind(Type type) => 
      Binds.GetValueOrDefault(type);

    public bool TryGetBind(Type type, out IInputBindBase bind)
    {
      bind = GetBind(type);
      if (bind == null)
        return false;
      return true;
    }
  }
}