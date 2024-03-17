using UnityEngine;

namespace Domain.Movement
{
    public class NaturalGravity : MonoBehaviour, IGravity
    {
        private Rigidbody2D _rb;
        private float _power;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (TryGetComponent(out Rigidbody2D rb))
            {
                _rb = rb;
            }
            else
            {
                throw new MissingComponentException();
            }
        }

        public void SetLevel(float level)
        {
            _rb.gravityScale = level;
        }

        public void Stop()
        {
            _power = _rb.gravityScale;
            _rb.gravityScale = 0f;
        }

        public void Restore()
        {
            _rb.gravityScale = _power;
        }
    }
}