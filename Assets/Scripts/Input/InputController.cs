using System;
using UnityEngine;
using Zenject;

namespace Domain.Movement.Input
{
    public class InputController : MonoBehaviour, IInput
    {
        public event Action OnTap;
        public event Action OnLongPress;
        public event Action OnEnded;

        private IConcreteInputSignature _concreteInput;

        [Inject]
        public void Initialize(IConcreteInputSignature concreteInput)
        {
            _concreteInput = concreteInput ?? throw new NullReferenceException();
        }

        private void Update()
        {
            if (_concreteInput.IsPressStarted())
            {
                OnTap?.Invoke();

                return;
            }

            if (_concreteInput.IsPressed())
            {
                OnLongPress?.Invoke();

                return;
            }

            if (_concreteInput.IsPressEnded())
            {
                OnEnded?.Invoke();
            }
        }
    }
}
