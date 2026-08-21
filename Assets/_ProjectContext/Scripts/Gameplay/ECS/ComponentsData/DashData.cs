using LitMotion;
using Unity.Entities;

namespace Scripts.Gameplay.ECS.ComponentsData
{
    public struct DashData : IComponentData
    {
        public float DashDistance;
        public float DashTime;
        public Ease DashEase;
        public bool IsDashing;
    }
}