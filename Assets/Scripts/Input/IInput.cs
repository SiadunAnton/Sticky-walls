using System;

namespace Domain.Movement.Input
{
    public interface IInput
    {
        public event Action OnTap;
        public event Action OnLongPress;
        public event Action OnEnded;
    }
}