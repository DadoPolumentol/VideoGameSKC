using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2.0f;
    public float yOffset = 0f;
    //public Transform target;

    public CinemachineCamera virtualCamera;  // Reference to the Cinemachine Virtual Camera
    public Transform player;                        // Reference to the Player
    public Transform boss;
    public Transform boss1;                        // Reference to the Boss
    public float zoomDistance = 10f;
    public float zoomSpeed = 3f;                    // Speed of the zoom effect
    float targetORTHO = 10f;
    float origionalORTHO;
    private void Start()
    {
        origionalORTHO = virtualCamera.Lens.OrthographicSize;
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToBoss = Vector3.Distance(player.position, boss.position);
        
        float distanceToBoss1 = Vector3.Distance(player.position, boss1.position);
        if (distanceToBoss < distanceToBoss1)
        {
            distanceToBoss = Vector3.Distance(player.position, boss.position);
        }
        else
        {
           distanceToBoss = Vector3.Distance(player.position, boss1.position);
        }

        // If the player is within a certain range of the boss, zoom out
        if (distanceToBoss <= zoomDistance)
        {
            
            virtualCamera.Lens.OrthographicSize = Mathf.Lerp(virtualCamera.Lens.OrthographicSize, targetORTHO, Time.deltaTime*zoomSpeed);
            Debug.Log(virtualCamera.Lens.OrthographicSize);
        }
        else
        {
            virtualCamera.Lens.OrthographicSize = Mathf.Lerp(virtualCamera.Lens.OrthographicSize, origionalORTHO, Time.deltaTime * zoomSpeed);

        }


        //Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        // transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
    
}
