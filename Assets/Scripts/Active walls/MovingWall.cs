using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interactions.Triggered
{
    public class MovingWall : ReactiveComponent
    {
        [SerializeField] private List<Transform> _path = new List<Transform>();
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _prewarmDelay = 0.5f;
        [SerializeField] private float _delay = 1f;
        [SerializeField] private bool _movingByTrigger = true;

        private bool _isReady = true;

        public override void OnEnter(GameObject anObject)
        {
            if (_isReady && _movingByTrigger)
            {
                _isReady = false;
                MoveByRoute(2);
            }
        }

        private void Awake()
        {
            if (!_movingByTrigger)
            {
                MoveByRoute(-1);
            }

        }

        

        private void MoveByRoute(int loops)
        {
            Tween tween = transform.DOPath(_path.Select(x => x.position).ToArray(),
                _duration, PathType.Linear, PathMode.Sidescroller2D, 10, Color.blue)
                    .SetEase(Ease.Linear);

            Sequence sequence = DOTween.Sequence();

            sequence.SetDelay(_prewarmDelay).Append(tween).AppendInterval(_delay).OnComplete(SetReady);

            sequence.SetLoops(loops, LoopType.Yoyo).Play();
        }

        private void SetReady()
        {
             _isReady = true;
        }

        public void OnDestroy()
        {
            DOTween.Clear(transform);
        }
    }
}
