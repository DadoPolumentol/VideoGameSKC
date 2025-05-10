using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    private float distance;
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private bool isFacingRight = true;
    private bool isFacingUp = true;



    private Vector3 lastPosition;
    public Vector3 velocity;

    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (distance < 10 && distance > 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        Flip();
    }
    private void FixedUpdate()
    {
        animator.SetFloat("xVelocity", Math.Abs(velocity.x));
            animator.SetFloat("yVelocity", velocity.y);
      
    }
    private void Flip()
    {
        if (isFacingRight && velocity.x < 0f || !isFacingRight && velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        if (isFacingUp && vertical < 0f || !isFacingUp && vertical > 0f)
        {
            isFacingUp = !isFacingUp;
        }
    }
}
