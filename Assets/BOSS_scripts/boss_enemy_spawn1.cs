using UnityEngine;

public class boss_enemy_spawn1 : StateMachineBehaviour
{
    public GameObject enemyPrefab;
    private Transform bossTransform;
    public int numberOfEnemies = 10;
    public float spawnRadius = 5f;
    public float spawnInterval = 10f;
    private float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossTransform = GameObject.FindGameObjectWithTag("Boss1").transform;
        timer = spawnInterval;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemiesAroundBoss();
        }
    }

    public void SpawnEnemiesAroundBoss()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Get random point inside a circle
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = bossTransform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
