using Scripts.Gameplay.ECS.ComponentsData.Tags;
using Unity.Entities;
using UnityEngine;

namespace Scripts.Gameplay.ECS.Authoring
{
    [RequireComponent(typeof(WalkMovementAuthoring))]
    [RequireComponent(typeof(CreatureHealthAuthoring))]
    public class EnemyAuthoring : MonoBehaviour
    {
        private class EnemyAuthoringBaker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerTag());
            }
        }
    }
}