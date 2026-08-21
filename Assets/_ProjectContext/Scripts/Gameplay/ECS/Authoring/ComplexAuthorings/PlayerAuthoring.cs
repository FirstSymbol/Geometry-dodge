using Scripts.Gameplay.ECS.ComponentsData.Tags;
using Unity.Entities;
using UnityEngine;

namespace Scripts.Gameplay.ECS.Authoring
{
    [RequireComponent(typeof(DashMovementAuthoring), typeof(WalkMovementAuthoring))]
    [RequireComponent(typeof(CreatureHealthAuthoring))]
    public class PlayerAuthoring : MonoBehaviour
    {
        private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerTag());
            }
        }
    }
}