using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public Healthbar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    public string enemyLayerName = "Enemy";
    public string sendvicLayerName = "Sendvic";
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer(enemyLayerName))
        {
            Debug.Log("enemy");
            TakeDamage(20);
        }
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(sendvicLayerName))
        {
            Debug.Log("sendvic");
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
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
