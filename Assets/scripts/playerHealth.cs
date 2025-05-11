using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public Healthbar healthBar;
    public GameObject gameOverScreen;

    public int maxHealth = 100;
    public int currentHealth;
    public string enemyLayerName = "Enemy";
    public string sendvicLayerName = "Sendvic";
    public Animator animator;
    private SpriteRenderer sr;
    private Color originalColor;
    void Start()
    {
        gameOverScreen.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer(enemyLayerName))
        {
         
            TakeDamage(20);
        }
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(sendvicLayerName))
        {
          
            TakeDamage(10);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
         currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            gameOverScreen.SetActive(true);   
            
            
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
