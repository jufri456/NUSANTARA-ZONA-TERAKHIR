using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Music")]
    public AudioClip lobbyMusic;
    public AudioClip battleMusic;
    public AudioClip victoryMusic;

    [Header("Sound Effects")]
    public AudioClip buttonSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || musicSource == null)
            return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }

    public void PlayButtonSound()
    {
        PlaySFX(buttonSound);
    }

    public void PlayVictorySound()
    {
        PlaySFX(winSound);
        PlayMusic(victoryMusic);
    }

    public void PlayLoseSound()
    {
        PlaySFX(loseSound);
    }
}
