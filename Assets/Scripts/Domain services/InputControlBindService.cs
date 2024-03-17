using UnityEngine;
using System;
using Zenject;
using Domain.Movement.JumpController;
using Domain.Movement.Input;

namespace Domain.Services
{
    public class InputControlBindService : MonoBehaviour
    {
        private IInput _input;
        private ILongJumpBehaviour _jumpControl;

        [Inject]
        public void Initialize(IInput input, ILongJumpBehaviour jumpControl)
        {
            if (input == null || jumpControl == null)
                throw new NullReferenceException();

            _input = input;
            _jumpControl = jumpControl;
        }

        private void Start()
        {
            Bind();
        }

        public void Bind()
        {
            _input.OnTap += _jumpControl.BaseJump;
            _input.OnLongPress += _jumpControl.AdditionalJump;
            _input.OnEnded += _jumpControl.JumpEnd;
        }
    }
}