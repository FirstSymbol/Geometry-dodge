using Cysharp.Threading.Tasks;
using ExtDebugLogger;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using WindowsSystem;
using WindowsSystem.Providers;

namespace Infrastructure.StateMachines.States
{
  public class InitializationWindowsServiceState : BaseInitializationState
  {
    private IWindowsService _windowsService;
    private IWindowsProvider _windowsProvider;
    
    public InitializationWindowsServiceState(IWindowsService windowsService, IWindowsProvider windowsProvider, InitializationStateMachine stateMachine) : base(stateMachine)
    {
      _windowsService = windowsService;
      _windowsProvider = windowsProvider;
    }

    public override UniTask Exit()
    {
      return UniTask.CompletedTask;
    }

    public override UniTask Enter()
    {
      
      
      stateMachine.NextState();
      return UniTask.CompletedTask;
    }
  }
}