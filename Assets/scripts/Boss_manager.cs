using UnityEngine;

public class Boss_manager : MonoBehaviour
{
    public GameObject winCanvas;  // The Canvas to show when both bosses are dead
    private int deadBossCount = 0;
    private void Start()
    {
        winCanvas.SetActive(false);
    }
    // Call this when a boss dies
    public void BossDied()
    {
        deadBossCount++;

        if (deadBossCount >= 2)
        {
            Debug.Log("Both bosses are dead!");
            winCanvas.SetActive(true);
        }
    }
}
