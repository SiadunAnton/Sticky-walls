using UnityEngine;
using Zenject;

namespace Domain.Interactions.Triggered
{
    public class TriggerContainer : MonoBehaviour
    {
        protected string characterTag;

        private ReactiveComponent[] _reactives;

        [Inject]
        public void Initialize([Inject(Id = "CharacterTag")] string tag)
        {
            characterTag = tag;
        }

        private void Start()
        {
            _reactives = GetComponents<ReactiveComponent>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(characterTag))
            {
                foreach (var reactive in _reactives)
                    reactive.OnEnter(collision.gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag(characterTag))
            {
                foreach (var reactive in _reactives)
                    reactive.OnStay(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(characterTag))
            {
                foreach (var reactive in _reactives)
                    reactive.OnExit(collision.gameObject);
            }
        }
    }
}