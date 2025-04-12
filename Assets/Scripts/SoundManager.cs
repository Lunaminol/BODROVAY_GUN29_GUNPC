using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _moveSound;
    [SerializeField]
    private AudioClip _bumpSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = _moveSound;
        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(_bumpSound);
    }
}

