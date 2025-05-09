using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject sendvic;
    public Transform sendvicPosition;

    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 10)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                Shoot();

            }
        }
      
    }
    void Shoot()
    {
        Instantiate(sendvic,sendvicPosition.position, Quaternion.identity);
    }
}
