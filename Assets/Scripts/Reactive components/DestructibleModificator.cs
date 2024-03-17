using System.Collections;
using UnityEngine;

namespace Domain.Interactions.Triggered
{
    public class DestructibleModificator : ReactiveComponent
    {
        [SerializeField] private float _cooldown = 2f;
        [SerializeField] private Animator _animator;

        private BoxCollider2D[] _colliders;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _colliders = GetComponents<BoxCollider2D>();
            _renderer = GetComponent<SpriteRenderer>();

            if (_colliders == null || _renderer == null)
                throw new System.NullReferenceException("Wall doesn't have a collider or renderer.");
        }

        public override void OnExit(GameObject anObject)
        {
            StartCoroutine(DisableColliderForTime());
        }

        private IEnumerator DisableColliderForTime()
        {
            if (_cooldown < 0)
                throw new System.ArgumentException("Cooldawn value must be non-zero value.");

            _animator.SetTrigger("Destroy");
            DisableWall();
            yield return new WaitForSeconds(_cooldown);
            EnableWall();
        }

        private void DisableWall()
        {
            foreach (var collider in _colliders)
                collider.enabled = false;
        }

        private void EnableWall()
        {
            foreach (var collider in _colliders)
                collider.enabled = true;
        }
    }
}