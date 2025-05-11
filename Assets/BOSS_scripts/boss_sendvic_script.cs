using System.Threading;
using UnityEngine;

public class boss_sendvic_script : MonoBehaviour
{
    
  
    private GameObject boss;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        Vector3 direction = boss.transform.position - transform.position;
        rb.linearVelocity = new Vector2(-direction.x, -direction.y).normalized * force;
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
