using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Creatures;
using UnityEngine;

namespace Gameplay
{
  public class EnemyProjectile : MonoBehaviour
  {
    public float Damage => damage;
    public float Speed => speed;
    [SerializeField] private int damage = 10;
    [SerializeField] private int speed = 5;
    [SerializeField, Range(0, 30)] private float lifeTime = 10f;
    private bool _isLaunched;
    private CancellationTokenSource _cts;

    private void Awake()
    {
      _cts = new CancellationTokenSource();
    }

    public async UniTask Launch()
    {
      if (_isLaunched) return;
      _isLaunched = true;
      float time = 0f;
      while (time < lifeTime && !_cts.IsCancellationRequested)
      {
        transform.Translate(transform.up * (speed * Time.deltaTime),Space.World);
        time += Time.deltaTime;
        await UniTask.Yield(cancellationToken: _cts.Token);
      }
      Destroy(gameObject);
    }

    private void OnDestroy()
    {
      _cts.Cancel();
    }

    private void ShootHit(ICreature creature)
    {
      creature.Health.Damage(damage);
      _cts.Cancel();
      Destroy(gameObject);
    }
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
      if (collider.gameObject.layer != LayerMask.NameToLayer("Player")) return;
      if (collider.gameObject.TryGetComponent(out ICreature creature))
      {
        ShootHit(creature);
      }
    }
  }
}