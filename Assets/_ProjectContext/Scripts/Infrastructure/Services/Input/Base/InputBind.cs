using System;
using System.Collections.Generic;
using System.Linq;
using ExtDebugLogger;
using ModestTree;
using Zenject;

namespace Infrastructure.Services.Input
{
  public abstract class InputBind<T> : IMultiplyInputBind<T> where T : class
  {
    public bool AddBindingInstance(object bindingInstance)
    {
      if (bindingInstance == null)
        return false;

      if (bindingInstance is T instance)
        return AddBindingInstance(instance);
      return false;
    }

    public bool RemoveBindingInstance(object bindingInstance)
    {
      if (bindingInstance == null)
        return false;
      if (bindingInstance is T instance)
        return RemoveBindingInstance(instance);
      return false;
    }

    public bool IsBinded { get; private set; }
    protected abstract HashSet<T> BindedInstances { get; set; }
    protected readonly IInputService InputService;
    
    [Inject]
    protected InputBind(IInputService inputService)
    {
      InputService = inputService;
      BindedInstances = new HashSet<T>();
    }

    public bool AddBindingInstance(T bindingInstance) => 
      bindingInstance != null && BindedInstances.Add(bindingInstance);

    public bool RemoveBindingInstance(T bindingInstance) => 
      bindingInstance != null && BindedInstances.Remove(bindingInstance);

    public bool Bind()
    {
      if (IsBinded)
      {
        Logger.Warn($"{GetType().Name.Split('.')[^1] } is already bounded!", InputServiceLogTag.InputBindings);
        return true;
      }
      
      BindAction();
      Logger.Log($"{GetType().Name.Split('.')[^1] } bounded!", InputServiceLogTag.InputBindings);
      IsBinded = true;
      return IsBinded;
    }
    
    public bool UnBind()
    {
      if (!IsBinded)
      {
        Logger.Warn($"{GetType().Name.Split('.')[^1] } is already unbounded!", InputServiceLogTag.InputBindings);
        return false;
      }
      
      UnbindAction();
      Logger.Log($"{GetType().Name.Split('.')[^1] } unbounded!", InputServiceLogTag.InputBindings);
      IsBinded = false;
      return IsBinded;
    }
    
    protected abstract void BindAction();
    protected abstract void UnbindAction();
  }
}