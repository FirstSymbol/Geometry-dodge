using LitMotion;
using Scripts.Gameplay.ECS.ComponentsData;
using Unity.Entities;
using UnityEngine;

namespace Scripts.Gameplay.ECS.Authoring
{
    public class DashMovementAuthoring : MonoBehaviour
    {
        [Header("Dash")]
        [SerializeField] private float dashDistance = 0.65f;
        [SerializeField] private float dashTime = 0.1f;
        [SerializeField] private Ease dashEase = Ease.Linear;
        private class PlayerMovementAuthoringBaker : Baker<DashMovementAuthoring>
        {
            public override void Bake(DashMovementAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DashData()
                {
                    DashDistance = authoring.dashDistance,
                    DashTime     = authoring.dashTime,
                    DashEase     = authoring.dashEase,
                    IsDashing    = false
                });
            }
        }
    }
}