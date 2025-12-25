using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure.Entry
{
  public class EntryPointLoader : MonoBehaviour
  {
    private void Awake()
    {
      if (!EntryPoint.Initialized)
        SceneManager.LoadScene(0);
    }
  }
}