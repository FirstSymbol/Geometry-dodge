using System;
using Infrastructure.Services.Input;
using Infrastructure.Services.Input.Bindings;
using Scripts.Gameplay.ECS.Singletones;
using Scripts.Infrastructure.Entry;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Scripts.Gameplay.Mono
{
    public class PlayerInputSystemBridge : MonoBehaviour
    {
        [Inject] IInputBindingService _inputBindingService;
        private EntityQuery _query;
        private void Start()
        {
            if (!EntryPoint.Initialized) return;
            var bind = _inputBindingService.GetBind<PlayerWASDMovementBind>();
            bind.AddBindingInstance(WASDHandler);
            
            UpdateQuery();
        }

        private void UpdateQuery()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null) return;
            var entityManager = world.EntityManager;
            _query = entityManager.CreateEntityQuery(typeof(PlayerInputSingletonData));
            if (!_query.HasSingleton<PlayerInputSingletonData>()) 
                entityManager.CreateSingleton<PlayerInputSingletonData>();
        }

        private void WASDHandler(float2 vector)
        {
            if (_query.HasSingleton<PlayerInputSingletonData>())
            {
                var playerInputSingletonData = _query.GetSingletonRW<PlayerInputSingletonData>();
                playerInputSingletonData.ValueRW.Move.value = vector;
                playerInputSingletonData.ValueRW.Move.isTriggered = true;
            }
        }

        private void OnDestroy()
        {
            if (!EntryPoint.Initialized) return;
            var bind = _inputBindingService.GetBind<PlayerWASDMovementBind>();
            bind.RemoveBindingInstance(WASDHandler);
        }
    }
}