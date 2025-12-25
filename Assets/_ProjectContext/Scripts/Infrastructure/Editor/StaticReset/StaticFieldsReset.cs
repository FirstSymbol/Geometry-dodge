using Scripts.Infrastructure.Entry;
using UnityEditor;
using UnityEngine;

namespace Scripts.Infrastructure.StaticReset
{
  public static class StaticFieldsReset
  {
    [InitializeOnEnterPlayMode]
    private static void ResetStatic()
    {
      bool checkDomain = EditorSettings.enterPlayModeOptions.HasFlag(EnterPlayModeOptions.DisableDomainReload);
      if (!checkDomain)
        return;
      
      ResetEntryPoint();
    }

    private static void ResetEntryPoint()
    {
      EntryPoint.Initialized = false;
    }
  }
}