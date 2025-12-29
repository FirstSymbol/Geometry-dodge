using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input
{
  /// <summary>
  /// Store InputActions
  /// </summary>
  public class InputService : IInputService
  {
    private Dictionary<Type, IInputActionCollection> Inputs { get; set; } = new();

    public T GetInput<T>() where T : class, IInputActionCollection => 
      Inputs.GetValueOrDefault(typeof(T)) as T;

    public void Initialize(Dictionary<Type, IInputActionCollection> inputs) => 
      Inputs = inputs;

    public bool AddInput<T>(T inputInstance) where T : class, IInputActionCollection => 
      Inputs.TryAdd(typeof(T), inputInstance);
  }
}