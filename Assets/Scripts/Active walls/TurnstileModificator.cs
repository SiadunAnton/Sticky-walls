using System.Collections;
using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Active
{
    public class TurnstileModificator : MonoBehaviour
    {
        [SerializeField] private float _cooldown;

        private MainCharacter _character;
        private SpriteController _spriteController;

        [Inject]
        public void Initialize(MainCharacter character, SpriteController spriteController)
        {
            if (character == null)
                throw new System.NullReferenceException("Character is empty.");

            _character = character;
            _spriteController = spriteController;
        }

        private void Start()
        {
            StartCoroutine(TurnDirection());
        }

        public IEnumerator TurnDirection()
        {
            if (_cooldown <= 0)
                throw new System.ArgumentException("Cooldown must be a positive value.");

            for (; ; )
            {
                yield return new WaitForSeconds(_cooldown);
                yield return ChangeLocalScale();
            }
        }

        protected IEnumerator ChangeLocalScale()
        {
            yield return null;

            if( transform == _character.transform.parent)
            {
                _character.TurnBack();
                _spriteController.ReverseScale();
            }

            transform.localScale = new Vector3(-transform.localScale.x,
                                                transform.localScale.y,
                                                transform.localScale.z);
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
