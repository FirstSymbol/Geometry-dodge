namespace Infrastructure.Services.Input
{
  public interface IInputBindBase
  {
    public bool AddBindingInstance(IInputBindBase bindingInstance);
    public bool RemoveBindingInstance(IInputBindBase bindingInstance);
    bool IsBinded { get; }
    bool Bind();
    bool UnBind();
  }

  public interface IMultiplyInputBind<T> : IInputBindBase where T: class
  {
    public bool AddBindingInstance(T bindingInstance);
    public bool RemoveBindingInstance(T bindingInstance);
    
  }
}