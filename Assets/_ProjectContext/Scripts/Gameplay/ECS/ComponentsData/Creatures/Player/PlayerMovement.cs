using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using LitMotion;
using LitMotion.Extensions;
using Scripts.Infrastructure.Entry;
using UnityEngine;
using Zenject;

namespace Gameplay
{
  public class PlayerMovement : MonoBehaviour
  {
    [Inject] private IInputBindingService inputBindingService;
    [field: SerializeField] private Vector2 _velocity;
    public PlayerMovementGraphic playerMovementGraphic;
    public float speed = 5f;
    public float dashDistance = 0.65f;
    public float dashTime = 0.1f;
    public Ease dashEase = Ease.Linear;
    private bool isDashing;
    
    public Vector2 velocity
    {
      get => _velocity;
      set
      {
        _velocity = value.normalized;
        if (value != Vector2.zero)
        {
          _lastMemorableVelocity = value.normalized;
        }
      }
    }
    
    private Vector2 _lastMemorableVelocity = Vector2.right;
    private bool isZero;
    
    private PlayerWASDMovementBind playerWASDMovementBind;
    private PlayerDashMovementBind playerDashMovementBind;
    
    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;
      playerWASDMovementBind ??= inputBindingService.GetBind<PlayerWASDMovementBind>();
      playerDashMovementBind ??= inputBindingService.GetBind<PlayerDashMovementBind>();
      playerWASDMovementBind?.AddBindingInstance(this);
      playerDashMovementBind?.AddBindingInstance(this);
    }

    private void OnDisable()
    {
      playerWASDMovementBind?.RemoveBindingInstance(this);
      playerDashMovementBind?.RemoveBindingInstance(this);
    }

    private void Update()
    {
      if (velocity != Vector2.zero)
      {
        isZero = false;
        Move();
      }
      else
      {
        if (!isZero) 
          playerMovementGraphic.SetGraphic(in _velocity);
        isZero = true;
      }
    }

    public void Move()
    {
      velocity.Normalize();
      if (velocity.magnitude <= 0)
        return;
      
      transform.Translate(velocity * (speed * Time.deltaTime));
      playerMovementGraphic.SetGraphic(in _velocity);
    }

    public async void Dash()
    {
      if (isDashing) return;
      var value = _lastMemorableVelocity * dashDistance;
      var vector = new Vector3(transform.localPosition.x + value.x, transform.localPosition.y + value.y, transform.localPosition.z);
      isDashing = true;
      await LMotion.Create(transform.localPosition, vector, dashTime).WithEase(dashEase).BindToLocalPosition(transform);
      isDashing = false;
    }
  }
}