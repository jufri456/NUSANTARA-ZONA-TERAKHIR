using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;

    public void PlayFootstep()
    {
        if (audioSource == null ||
            footstepSounds == null ||
            footstepSounds.Length == 0)
            return;

        int index = Random.Range(
            0,
            footstepSounds.Length
        );

        audioSource.PlayOneShot(
            footstepSounds[index]
        );
    }
}
