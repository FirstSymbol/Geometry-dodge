using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input
{
  public interface IInputService
  {
    public T GetInput<T>() where T : class, IInputActionCollection;
    public void Initialize(Dictionary<Type, IInputActionCollection> inputs);
    public bool AddInput<T>(T inputInstance) where T : class, IInputActionCollection;
  }
}