using UnityEngine;

public class SFXscript : MonoBehaviour
{
    public AudioSource src;
    
    public void PlayClip(AudioClip clip)
    {
        src.clip = clip;
        src.Play();
    }
   
}
