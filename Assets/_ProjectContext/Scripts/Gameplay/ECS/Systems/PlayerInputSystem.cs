using Scripts.Gameplay.ECS.ComponentsData;
using Scripts.Gameplay.ECS.ComponentsData.Tags;
using Scripts.Gameplay.ECS.Singletones;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Scripts.Gameplay.ECS.Systems
{
    public partial struct PlayerInputSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerInputSingletonData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var inputSingleton = SystemAPI.GetSingleton<PlayerInputSingletonData>();
            foreach (var (movementData, playerTag) in SystemAPI.Query<RefRW<MovementData>, RefRO<PlayerTag>>())
            {
                if (inputSingleton.Move.isTriggered)
                {
                    movementData.ValueRW.Direction = new float3(inputSingleton.Move.value.x, inputSingleton.Move.value.y, 0f);
                    inputSingleton.Move.isTriggered = false;
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}