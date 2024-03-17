namespace Domain.Movement.Counters
{
    public interface ITimer
    {
        public float Current { get; }
        public float Duration { get; set; }

        public void Substract(float time);
        public void Reset();
    }
}