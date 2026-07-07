using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;


    public AudioSource audioSource;
    public AudioClip buttonClick;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}