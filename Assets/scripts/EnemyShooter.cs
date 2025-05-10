using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject sendvic;
    public Transform sendvicPosition;

    private float timer;
    private GameObject player;

    private Vector3 lastPosition;
    public Vector3 velocity;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 10 && velocity.x<0.5 && velocity.y <0.5)
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
