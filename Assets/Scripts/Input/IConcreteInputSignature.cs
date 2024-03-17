namespace Domain.Movement.Input
{
    public interface IConcreteInputSignature
    {
        public bool IsPressed();
        public bool IsPressStarted();
        public bool IsPressEnded();
    }
}