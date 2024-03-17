using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class ReparentModificator : ReactiveComponent
    {
        [SerializeField] private Transform _parent;

        private Transform _characterTransform;
        private Transform _cachedParent;

        [Inject]
        public void Initialize(MainCharacter character)
        {
            _characterTransform = character.gameObject.transform;
        }

        public override void OnEnter(GameObject anObject)
        {
            _cachedParent = _characterTransform.parent;
            _characterTransform.parent = _parent;
        }

        public override void OnExit(GameObject anObject)
        {
            _characterTransform.parent = _cachedParent;
        }
    }
}