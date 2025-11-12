using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        
        PlayBackgroundMusic();
    }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("Audio Clips")]
    public AudioClip celebrationClip;
    public AudioClip booingClip;
    public AudioClip backgroundMusicClip;

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicClip != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }
    
    public void StopBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying) backgroundMusicSource.Stop();
    }

    public void PlayCelebration()
    {
        if (sfxSource != null && celebrationClip != null) sfxSource.PlayOneShot(celebrationClip);
    }
    
    public void StopCelebration()
    {
        if (sfxSource != null && celebrationClip != null) sfxSource.Stop();
    }

    public void PlayBoos()
    {
        if (sfxSource != null && booingClip != null) sfxSource.PlayOneShot(booingClip);
    }

    public void StopBoos()
    {
        if (sfxSource != null && booingClip != null) sfxSource.Stop();
    }
}
