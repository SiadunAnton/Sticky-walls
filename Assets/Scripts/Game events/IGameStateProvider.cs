using System;

namespace Domain.Interactions.Triggered
{
    public interface IGameStateProvider
    {
        public event Action<GameState> OnStateChanged;

        public void SetState(GameState state);
        public void Notify();
    }
}