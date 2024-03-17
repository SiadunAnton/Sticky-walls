using System;
using UnityEngine;
using Zenject;
using Domain.Movement.JumpController;

namespace Domain.Interactions.Triggered
{
    public class JumpsResetComponent : ReactiveComponent
    {
        private ILongJumpBehaviour _jump;

        [Inject]
        public void Initialize(ILongJumpBehaviour jumpController)
        {
            _jump = jumpController ?? throw new NullReferenceException("Jump controller is empty.");
        }

        public override void OnEnter(GameObject anObject)
        {
            _jump.ResetJumpsCount();
        }
    }
}