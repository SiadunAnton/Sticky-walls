using UnityEngine;

namespace Domain.Movement
{
    public class PhysicMovement : MonoBehaviour, IMovement
    {
        public Vector2 Direction => _direction;

        [SerializeField] private Vector2 _force = new Vector2(0f, 10f);

        private Rigidbody2D _rb;
        private Vector2 _direction = Vector2.right;

        private void Awake()
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

        public void Jump(float multipier)
        {
            Vector2 force = multipier * new Vector2(_force.x * _direction.x, _force.y);
            _rb.AddForce(multipier * force);
        }

        public void TurnBack()
        {
            _direction *= -1;
        }

        public void TurnBackFrom(Vector3 target)
        {
            _direction = target.x > transform.position.x ? Vector2.left : Vector2.right ;
        }

        public void ResetVelocity()
        {
            _rb.velocity = new Vector2(0f, 0f);
        }

        public void SetVerticalVelocity(float velocity)
        {
            ResetVelocity();
            _rb.velocity = new Vector2(0f, velocity);
        }
    }
}