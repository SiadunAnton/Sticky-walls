using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _jumpsSound;

    public void Play()
    {
        _source.PlayOneShot(_jumpsSound);
    }
}
