using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;

    public Transform player;
    public float spawnRadius = 20f;
    private float _timeUntilSpawn;
     void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = (Vector2)player.position + randomOffset;
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime,_maximumSpawnTime);
    }
}
