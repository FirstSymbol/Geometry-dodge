using System;

namespace Infrastructure.Services.Input
{
  public interface IInputBindingService
  {
    bool AddBinding<T>() where T: class, IInputBindBase;
    T GetBind<T>() where T : class, IInputBindBase;
    IInputBindBase GetBind(Type type);
    bool TryGetBind<T>(out T bind) where T : class, IInputBindBase;
    bool TryGetBind(Type type, out IInputBindBase bind);
  }
}