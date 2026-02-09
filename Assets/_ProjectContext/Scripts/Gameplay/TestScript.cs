using System;
using _ProjectContext.Scripts.Gameplay.UI.Windows;
using UnityEngine;
using WindowsSystem;
using WindowsSystem.Providers;
using Zenject;

namespace Scripts.Gameplay
{
  public class TestScript : MonoBehaviour
  {
    public RectTransform windowsContainer;
    [Inject] private IWindowsService _windowsService;
    [Inject] private IWindowsProvider _windowsProvider;
    private void Start()
    {
      _windowsService.OpenWindow<SimpleWindow>(Vector2.zero, windowsContainer);
    }
  }
}