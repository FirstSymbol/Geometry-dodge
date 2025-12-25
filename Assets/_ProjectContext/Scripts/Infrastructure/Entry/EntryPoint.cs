using UnityEngine;

namespace Scripts.Infrastructure.Entry
{
  public class EntryPoint : MonoBehaviour
  {
    public static bool Initialized;

    private void Awake()
    {
      Initialized = true;
    }
  }
}