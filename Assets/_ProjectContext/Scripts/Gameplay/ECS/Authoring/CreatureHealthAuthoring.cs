using Scripts.Gameplay.ECS.ComponentsData;
using Unity.Entities;
using UnityEngine;

namespace Scripts.Gameplay.ECS.Authoring
{
    public class CreatureHealthAuthoring : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] private int maxHealthValue;
        [SerializeField] private int healthValue;
        private class HealthAuthoringBaker : Baker<CreatureHealthAuthoring>
        {
            public override void Bake(CreatureHealthAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CreatureHealthData
                {
                    HealthValue = authoring.healthValue,
                    MaxHealthValue = authoring.maxHealthValue
                });
            }
        }
    }
}