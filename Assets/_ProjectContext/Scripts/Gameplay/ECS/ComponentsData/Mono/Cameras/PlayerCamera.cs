using System;
using Scripts.Gameplay.ECS.ComponentsData.Tags;
using Scripts.Infrastructure.Entry;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Cameras
{
  public enum PivotAlign
  {
    Center,
    LeftTop,
    RightTop,
    RightBottom,
    LeftBottom,
  }
  public class PlayerCamera : MonoBehaviour
  {
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 maxMouseLookOffset;
    [SerializeField] private Vector2 moveBox;
    [SerializeField] private PivotAlign pivotAlign;
    private EntityQuery _playerQuery;

    private void Start()
    {
      if (!EntryPoint.Initialized)
      {
        return;
      }

      var world = World.DefaultGameObjectInjectionWorld;
      if (world == null)
      {
        return;
      }
      var em =  world.EntityManager;
      _playerQuery = em.CreateEntityQuery(ComponentType.ReadOnly<PlayerTag>(), ComponentType.ReadOnly<Unity.Transforms.LocalTransform>());
    }
    
    private Entity FindPlayerEntity()
    {
      int count = _playerQuery.CalculateEntityCount();
      if (count == 0) return Entity.Null;

      using (NativeArray<Entity> entities = _playerQuery.ToEntityArray(Allocator.Temp))
      {
        return entities[0]; 
      }
    }

    private void LateUpdate()
    {
      MoveToTarget();
    }

    private void MoveToTarget()
    {
      var playerEntity = FindPlayerEntity();
      var em = World.DefaultGameObjectInjectionWorld.EntityManager;
      if (!em.HasComponent<Unity.Transforms.LocalTransform>(playerEntity))
        return;
      Unity.Transforms.LocalTransform playerTransform = em.GetComponentData<Unity.Transforms.LocalTransform>(playerEntity);
      
      var screenCenter = new Vector2(Screen.width/2, Screen.height/2);
      
      var t = MoveMouseOffset();
      var tv = new Vector2(screenCenter.x + t.x, screenCenter.y + t.y);
      tv = _mainCamera.ScreenToWorldPoint(tv);
      var screenCenterWorld = _mainCamera.ScreenToWorldPoint(screenCenter);
      tv = new Vector2(tv.x - screenCenterWorld.x, tv.y - screenCenterWorld.y);
      transform.position = new Vector3(playerTransform.Position.x + tv.x,playerTransform.Position.y + tv.y,transform.position.z);
      
    }

    private Vector2 MoveMouseOffset()
    {
      var mousePosition = Mouse.current.position.ReadValue();
      var screenCenter = new Vector2(Screen.width/2, Screen.height/2);

      mousePosition -= screenCenter;
      
      var direction = new Vector2(mousePosition.x / screenCenter.x, mousePosition.y / screenCenter.y);
      
      if (mousePosition.x > screenCenter.x)
      {
        direction.x *= -1;
      }
      if (mousePosition.y > screenCenter.y)
      {
        direction.y *= -1;
      }
      
      var offset = new Vector2(direction.x * maxMouseLookOffset.x, direction.y * maxMouseLookOffset.y);
      return offset;
    }
  }
}