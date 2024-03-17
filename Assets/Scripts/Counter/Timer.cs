using System;

namespace Domain.Movement.Counters
{
    public class Timer : ITimer
    {
        public float Current => _last;

        public float Duration
        {
            get => _duration;
            set
            {
                if (value < 0) throw new ArgumentException("Incorrect duration.");
                _duration = value;
            }
        }

        private float _duration;
        private float _last;

        public void Reset()
        {
            _last = _duration;
        }

        public void Substract(float time)
        {
            _last -= time;
            if (_last <= 0) _last = 0;
        }
    }
}