using Scripts.Gameplay.ECS.ComponentsData;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

namespace Scripts.Gameplay.ECS.Systems
{
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (movementData, velocity) in SystemAPI.Query<RefRO<MovementData>, RefRW<PhysicsVelocity>>())
            {
                velocity.ValueRW.Linear = movementData.ValueRO.Direction * movementData.ValueRO.Speed;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}