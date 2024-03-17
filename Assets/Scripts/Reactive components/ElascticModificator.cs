using UnityEngine;
using Zenject;
using Domain.Movement;
using Domain.Movement.JumpController;

namespace Domain.Interactions.Triggered
{
    public class ElascticModificator : ReactiveComponent
    {
        [SerializeField] private float _pushForceMultipier;

        private ICharacter _character;
        private ILongJumpBehaviour _jumpBehaviour;

        [Inject]
        public void Initialize(ICharacter character, ILongJumpBehaviour jumpBehaviour)
        {
            _character = character;
            _jumpBehaviour = jumpBehaviour;
        }

        public override void OnEnter(GameObject anObject)
        {
            _character.Stop();
            _character.TurnBack();
            _character.Pulse(_pushForceMultipier);
        }

        public override void OnExit(GameObject anObject)
        {
            _character.Restore();
            _jumpBehaviour.DecreaseJump();
        }
    }
}