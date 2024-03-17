namespace Domain.Movement.JumpController
{
    public interface ILongJumpBehaviour
    {
        public void BaseJump();
        public void AdditionalJump();
        public void JumpEnd();
        public void DecreaseJump();
        public void ResetJumpsCount();
    }
}