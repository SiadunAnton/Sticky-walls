namespace Domain.Movement.Counters
{
    public interface ICounter
    {
        public int Current { get; }
        public int Count { get; set; }

        public void Decrement();
        public void Reset();
    }
}