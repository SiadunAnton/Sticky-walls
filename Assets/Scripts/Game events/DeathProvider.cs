using System;

namespace Domain.Interactions.Triggered
{
    public class DeathProvider : IGameStateProvider
    {
        public event Action<GameState> OnStateChanged;
        public GameState State => _state;

        private GameState _state;

        public void Notify()
        {
            OnStateChanged?.Invoke(_state);
        }

        public void SetState(GameState state)
        {
            _state = state;
            Notify();
        }
    }
}
