using Scripts.Gameplay.ECS.ComponentsData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Scripts.Gameplay.ECS.Authoring
{
    public class WalkMovementAuthoring : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 5f;
        private class MovementAuthoringBaker : Baker<WalkMovementAuthoring>
        {
            public override void Bake(WalkMovementAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MovementData()
                {
                    Direction = float3.zero,
                    Speed     = authoring.speed
                });
            }
        }
    }
}