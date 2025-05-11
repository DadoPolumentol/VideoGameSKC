using UnityEngine;

public class bossHP : MonoBehaviour
{
    public Healthbar healthBar;
    public int maxHealth = 4;
    public int currentHealth;
    private Color originalColor;
    private SpriteRenderer sr;
    public GameObject gameWonScreen;

    public Animator animator;
    void Start()
    {
        gameWonScreen.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
  

    }
    public void TakeDamage(int health)
    {
        animator.SetTrigger("hurt");

        currentHealth -= health;
        try
        {
            animator.SetInteger("boss_hp", currentHealth);
            healthBar.SetHealth(currentHealth);


        }
        catch
        {

        }

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Die();
            GetComponent<Collider2D>().enabled = false;
            try
            {
                GetComponent<AIChase>().enabled = false;
                GetComponent<EnemyShooter>().enabled = false;
            }
            catch
            {
                Debug.Log("lol");
            }
            this.enabled = false;


        }
        else
        {
            FlashRed();
        }
    }
    public void FlashRed()
    {
        StartCoroutine(FlashCoroutine());
    }

    private System.Collections.IEnumerator FlashCoroutine()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sr.color = originalColor;
    }
    public void Die()
    {
        StartCoroutine(Die_cououtine());
    }

    private System.Collections.IEnumerator Die_cououtine()
    {
        
        yield return new WaitForSeconds(3f);
        gameWonScreen.SetActive(true);
    }

}