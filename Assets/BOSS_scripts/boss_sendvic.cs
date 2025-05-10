using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_sendvic : StateMachineBehaviour
{
    public GameObject Boss_sendvic;
    public int numberToSpawn = 8;
    public float radius = 5f;

    Transform player1;
    Transform boss;
    Rigidbody2D rb;
    private float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player1 = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Transform>();

    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            Shoot();

        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
    void Shoot()
    {
        Vector3 center = boss.position;
        center.z = 0;
        for (int i = 0; i < numberToSpawn; i++)
        {
            float angle = i * Mathf.PI * 2f / numberToSpawn;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;


            Vector3 spawnPos = new Vector3(x, y, 0) + center;
            Instantiate(Boss_sendvic, spawnPos, Quaternion.identity);
        }
    }

}
