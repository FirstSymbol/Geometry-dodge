using Unity.Entities;
using Unity.Mathematics;

namespace Scripts.Gameplay.ECS.Singletones
{
    public struct PlayerInputSingletonData : IComponentData
    {
        public (float2 value, bool isTriggered) Move;
        
        public bool Attack;
        public bool Interact;
        public bool Dash;
    }
}