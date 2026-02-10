using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
  public class EnemyAI : MonoBehaviour
  {
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooting enemyShooting;

    [SerializeField] private float shootRate = 1f;
    [SerializeField] private CancellationTokenSource _shootCts;
    private void OnEnable()
    {
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
        enemyShooting.Shoot();
      }
    }
  }
}