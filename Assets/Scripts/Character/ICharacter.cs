using UnityEngine;

namespace Domain.Movement
{
    public interface ICharacter
    {
        public bool IsGrounded { get; }

        public void SecondJump();
        public void Jump();
        public void Pulse(float force);
        public void Stop();
        public void Restore();
        public void AddClutch(float force);
        public void TurnBack();
        public void TurnBackFrom(Vector3 target);
    }
}