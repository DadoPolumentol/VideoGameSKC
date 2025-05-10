using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int health)
    {
        animator.SetTrigger("hurt");
        currentHealth -= health;
        if(currentHealth <= 0)
        {
            animator.SetBool("isDead",true);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AIChase>().enabled = false;
            GetComponent<EnemyShooter>().enabled = false;
            this.enabled = false;   
           
            
        }
    }
}
