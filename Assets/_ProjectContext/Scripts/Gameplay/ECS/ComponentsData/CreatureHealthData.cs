using Unity.Entities;

namespace Scripts.Gameplay.ECS.ComponentsData
{
    public struct CreatureHealthData : IComponentData
    {
        public int MaxHealthValue;
        public int HealthValue;

        public CreatureHealthData(int healthValue = 100, int maxHealthValue = 100)
        {
            HealthValue = healthValue;
            MaxHealthValue = maxHealthValue;
        }
    }
}