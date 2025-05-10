using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4f;
    private bool isFacingRight = true;
    private bool isFacingUp = true;

    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;
    bool isDashing;
    bool canDash = true;
    public TrailRenderer trailRenderer;
    public bool isKeyPressed = false;

    Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isKeyPressed = Input.GetKey(KeyCode.E);
        Flip();
        Dash();
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(horizontal * speed, vertical * speed));
        animator.SetFloat("xVelocity",Math.Abs(rb.totalForce.x));
        animator.SetFloat("yVelocity", rb.totalForce.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
    public void Dash()
    {
        if(isKeyPressed && canDash)
        {
            animator.SetTrigger("dash");
            Debug.Log("radi");
            StartCoroutine(DashCoroutine());
            
        }
    }
    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        trailRenderer.emitting = true;
        float dashDirectionx = isFacingRight ? 1f : -1f;
        float dashDirectiony = isFacingUp ? 1f : -1f;
        Vector2 movementDirection = rb.linearVelocity.normalized;
        rb.AddForce(new Vector2(movementDirection.x*dashSpeed, movementDirection.y * dashSpeed));

        yield return new WaitForSeconds(dashDuration); 

        rb.AddForce(new Vector2(0f, rb.linearVelocity.y));
        isDashing = false;
        trailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
