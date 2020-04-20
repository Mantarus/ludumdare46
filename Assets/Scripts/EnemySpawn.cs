using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform player;
    public Transform bed;
    public GameObject enemyPrefab;
    public float initialSpawnRate = 1f;
    public float spawnRateMultiplier = 1.1f;

    private float _spawnRate;
    private float _lastSpawn = 0f;

    private void Start()
    {
        _spawnRate = initialSpawnRate;
    }

    private void Update()
    {
        if (Time.time > _lastSpawn + 1f / _spawnRate)
        {
            _spawnRate *= spawnRateMultiplier;
            _lastSpawn = Time.time;
            Spawn();
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        var enemyMover = enemy.GetComponent<EnemyMover>();
        enemyMover.player = player;
        enemyMover.bed = bed;
    }
}
