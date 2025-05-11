using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss_sendvic : StateMachineBehaviour
{
    public AudioClip sendvic_sfx;
    private SFXscript SFX;

    public GameObject Boss_sendvic;
    public int numberToSpawn = 8;
    public float radius = 5f;

    Transform player1;
    Transform boss;
    Rigidbody2D rb;
    private float timer;
    public float cadence = 3f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player1 = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Transform>();
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXscript>();

    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        timer += Time.deltaTime;
        if (timer > cadence && Vector2.Distance(player1.position, boss.position) <10f)
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
        SFX.PlayClip(sendvic_sfx);
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
