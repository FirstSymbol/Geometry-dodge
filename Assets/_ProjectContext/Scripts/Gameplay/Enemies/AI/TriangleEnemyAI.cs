using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Movement;
using Gameplay.Shooting;
using Scripts.Infrastructure.Entry;
using UnityEngine;

namespace Gameplay
{
  public class TriangleEnemyAI : MonoBehaviour
  {
    [SerializeField] private DefaultEnemyMovement enemyMovement;
    [SerializeField] private DefaultEnemyShooting defaultEnemyShooting;

    [SerializeField] private float shootRate = 1f;
    
    private CancellationTokenSource _shootCts;
    private void OnEnable()
    {
      if (!EntryPoint.Initialized)
        return;
      _shootCts = new CancellationTokenSource();
      ShootRoutine().Forget();
    }

    private void OnDisable()
    {
      _shootCts?.Cancel();
      _shootCts?.Dispose();
    }

    private void Update()
    {
      enemyMovement.Move();
    }

    private async UniTask ShootRoutine()
    {
      while (_shootCts.IsCancellationRequested == false)
      {
        await UniTask.WaitForSeconds(shootRate);
        defaultEnemyShooting.Shoot();
      }
    }
  }
}