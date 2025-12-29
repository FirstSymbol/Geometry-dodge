using ExtDebugLogger.Attributes;
using ExtInspectorTools;
using Infrastructure.Services.Input;
using Infrastructure.StateMachines;
using UnityEngine;

namespace _ProjectContext.Scripts.Infrastructure.Configs.Log
{
  [CreateAssetMenu(fileName = "ColorTagColors Config", menuName = "Configs/ColorTags/ColorTagColors", order = 0)]
  public class ColorTagColorsConfig : ScriptableObject
  {
    [field: SerializeField, ExtDebugLoggerTags]
    public SerializableDictionary<StateMachineLogTag, Color> stateMachinesColors { get; private set;}
    [field: SerializeField, ExtDebugLoggerTags]
    public SerializableDictionary<InputServiceLogTag, Color> inputServiceColors { get; private set;}
  }
}