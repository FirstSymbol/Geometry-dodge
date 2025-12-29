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
    public bool AddBindingInstance(IInputBindBase bindingInstance)
    {
      if (bindingInstance == null)
        return false;
      var value = ExtractSelfTypeFromParent(bindingInstance);
      return value != null && AddBindingInstance(bindingInstance as InputBind<T>);
    }

    public bool RemoveBindingInstance(IInputBindBase bindingInstance)
    {
      if (bindingInstance == null)
        return false;
      var value = ExtractSelfTypeFromParent(bindingInstance);
      return value != null && RemoveBindingInstance(bindingInstance as InputBind<T>);
    }

    private static Type ExtractSelfTypeFromParent(IInputBindBase bindingInstance) => 
      bindingInstance.GetType().GetParentTypes().Select(t => t == typeof(InputBind<T>) ? t : null).First();

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