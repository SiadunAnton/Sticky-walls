namespace Domain.Movement.Input
{
    public class TestInputSignature : IConcreteInputSignature
    {
        public bool PressedValue = false;
        public bool PressStartedValue = false;
        public bool PressEndedValue = false;

        public bool IsPressed()
        {
            return PressedValue;
        }

        public bool IsPressEnded()
        {
            return PressEndedValue;
        }

        public bool IsPressStarted()
        {
            return PressStartedValue;
        }
    }
}
