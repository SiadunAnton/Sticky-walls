using System;
using UnityEngine;
using Zenject;
using Domain.Movement.Counters;

namespace Domain.Movement.JumpController
{
    public class LongJump : MonoBehaviour, ILongJumpBehaviour
    {
        [SerializeField] private float _jumpDuration;
        [SerializeField] private int _jumpsCount;
        [SerializeField] private JumpPlayer _player;

        public int CurrentCount;

        private ICharacter _character;
        private ICounter _counter;
        private ITimer _timer;
        private bool _jumpContinue = false;

        private void Update()
        {
            if (_counter != null)
                CurrentCount = _counter.Current;

        }

        [Inject]
        public void Initialize(ICharacter character, ICounter counter, ITimer timer)
        {
            if (character == null || counter == null || timer == null)
                throw new NullReferenceException();

            _character = character;
            _counter = counter;
            _timer = timer;

            if (_jumpDuration < 0 || _jumpsCount < 0)
                throw new ArgumentException("The long jump params are invalid.");

            _timer.Duration = _jumpDuration;
            _counter.Count = _jumpsCount;

            _timer.Reset();
            _counter.Reset();
        }

        public void ResetJumpsCount()
        {
            _counter.Reset();
        }

        public void BaseJump()
        {
            if (_character.IsGrounded)
            {
                ReleaseJump();
                return;
            }
            else if (_counter.Current == _counter.Count)
            {
                ReleaseJump();
                return;
            }
            else if (_counter.Current > 0)
            {
                _character.TurnBack();
                ReleaseJump();
            }
        }

        private void ReleaseJump()
        {
            _player.Play();
            _counter.Decrement();
            _character.Jump();
            _jumpContinue = true;
        }

        public void AdditionalJump()
        {
            if (_jumpContinue)
            {
                if (_timer.Current > 0)
                {
                    _character.SecondJump();
                    _timer.Substract(Time.deltaTime);
                }
                else
                {
                    _jumpContinue = false;
                    _timer.Reset();
                }
            }
        }

        public void JumpEnd()
        {
            _jumpContinue = false;
        }

        public void DecreaseJump()
        {
            _counter.Decrement();
        }
    }
}