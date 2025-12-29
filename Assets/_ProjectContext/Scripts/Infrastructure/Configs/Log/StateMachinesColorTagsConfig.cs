using ExtDebugLogger.Attributes;
using ExtDebugLogger.Interfaces;
using ExtInspectorTools;
using Infrastructure.StateMachines;
using UnityEngine;

namespace _ProjectContext.Scripts.Infrastructure.Configs.Log
{
  [CreateAssetMenu(fileName = "StateMachinesColorTags Config", menuName = "Configs/ColorTags/StateMachinesColorTags", order = 0)]
  public class StateMachinesColorTagsConfig : ScriptableObject, IKeepSeriaizableLoggerTags<StateMachineLogTag>
  {
    [field: SerializeField, ExtDebugLoggerTags]
    public SerializableDictionary<StateMachineLogTag, Color> ColorDictionary { get; private set;}
  }
}