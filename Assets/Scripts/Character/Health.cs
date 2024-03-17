using UnityEngine;
using System;
using Zenject;
using Domain.Interactions.Triggered;

public class Health : MonoBehaviour
{
    public event Action<int> OnChanged;
    public int Max => _count;

    [Min(0)]
    [SerializeField] private int _count;

    private int _currentCount;
    private IGameStateProvider _stateProvider;

    [Inject]
    public void Initialize(IGameStateProvider provider)
    {
        _stateProvider = provider ?? throw new NullReferenceException("Provider is empty.");
    }

    private void Awake()
    {
        Reset();
    }

    private void Start()
    {
        _stateProvider.OnStateChanged += x =>
        {
            if (x != GameState.Dead)
                return;
            _currentCount--;
            OnChanged?.Invoke(_currentCount);
            if (_currentCount == 0)
            {
                _stateProvider.SetState(GameState.End);
                _stateProvider.Notify();
                Reset();
            }
        };
    }

    private void Reset()
    {
        _currentCount = _count;
    }
}
