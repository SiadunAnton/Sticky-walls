using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            _animator.SetTrigger("OnGround");
        }
        else if(collision.CompareTag("Wall"))
        {
            _animator.SetTrigger("OnWall");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            _animator.SetTrigger("OnAir");
        }
    }
}
