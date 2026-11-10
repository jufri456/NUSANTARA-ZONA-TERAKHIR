using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip emptySound;

    public void PlayShoot()
    {
        PlaySound(shootSound);
    }

    public void PlayReload()
    {
        PlaySound(reloadSound);
    }

    public void PlayEmpty()
    {
        PlaySound(emptySound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }
}
