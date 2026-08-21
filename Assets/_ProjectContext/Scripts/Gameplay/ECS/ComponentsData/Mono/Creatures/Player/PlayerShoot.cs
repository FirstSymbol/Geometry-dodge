using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Infrastructure.Entry;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay
{
  public class PlayerShoot : MonoBehaviour
  {
    [Inject] private IInputBindingService  _inputBindingService;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerProjectile projectilePrefab;
    [SerializeField] private Transform projectileContainer;

    private PlayerShootBind _playerShootBind;
    
    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;

      _playerShootBind ??= _inputBindingService.GetBind<PlayerShootBind>();
      _playerShootBind?.AddBindingInstance(this);
    }

    private void OnDisable()
    {
      if (!EntryPoint.Initialized)
        return;
      
      _playerShootBind?.RemoveBindingInstance(this);
    }

    public void ShootDefault()
    {
      var mousePosition = Mouse.current.position.ReadValue();
      var selfPosition = (Vector2)mainCamera.WorldToScreenPoint(transform.position);
      
      var difference = mousePosition - selfPosition;
      var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90;
      
      PlayerProjectile projectile = Object.Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,angle), projectileContainer);
      projectile.Launch().Forget();
    }
  }
}