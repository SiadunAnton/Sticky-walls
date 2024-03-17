using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class SlidingModificator : ReactiveComponent
    {
        [SerializeField] private float _clutch;
        [SerializeField] private SpriteController _spriteController;

        private ICharacter _character;

        [Inject]
        public void Initialize(ICharacter character, SpriteController spriteController)
        {
            _character = character;
            _spriteController = spriteController;
        }

        public override void OnEnter(GameObject anObject)
        {
            _spriteController.ScaleToObject(transform.position);
            _character.TurnBackFrom( transform.position);
            _character.Stop();
        }

        public override void OnExit(GameObject anObject)
        {
            _spriteController.ReverseScale();
            _character.Restore();
        }

        public override void OnStay(GameObject anObject)
        {
            _character.AddClutch(_clutch);
        }
    }
}