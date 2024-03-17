using System;

namespace Domain.Movement.Counters
{
    public class Counter : ICounter
    {
        public int Current => _last;

        public int Count
        {
            get => _count;
            set
            {
                if (value < 0) throw new ArgumentException("Incorrect duration.");
                _count = value;
            }
        }

        private int _count;
        private int _last;

        public void Decrement()
        {
            _last -= 1;
            if (_last < 0) _last = 0;
        }

        public void Reset()
        {
            _last = _count;
        }
    }
}
