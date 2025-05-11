using UnityEngine;

public class boss_big_sendvic : StateMachineBehaviour
{
    public AudioClip sendvic_sfx;
    private SFXscript SFX;

    public GameObject Boss_sendvic;
    public int numberToSpawn = 1;
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
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXscript>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
