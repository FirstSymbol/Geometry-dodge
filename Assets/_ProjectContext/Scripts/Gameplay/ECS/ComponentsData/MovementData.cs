using Unity.Entities;
using Unity.Mathematics;

namespace Scripts.Gameplay.ECS.ComponentsData
{
    public struct MovementData : IComponentData
    {
        public float Speed;
        public float3 Direction;
    }
}