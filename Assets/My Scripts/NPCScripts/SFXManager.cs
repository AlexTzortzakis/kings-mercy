using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] private AudioSource soundEffects;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySound(AudioClip clip, Transform position)
    {
        AudioSource audioSource = Instantiate(soundEffects, position.position, Quaternion.identity);

        audioSource.clip = clip;

        audioSource.Play();

        float clipLength = clip.length;
        
        Destroy(audioSource.gameObject, clipLength);
    }
}
