using UnityEngine;
using Zenject;

namespace Domain.Interactions.Triggered
{
    public class DangerousModificator : ReactiveComponent
    {
        private IGameStateProvider _provider;

        [Inject]
        public void Initialize(IGameStateProvider provider)
        {
            _provider = provider;
        }

        public override void OnEnter(GameObject anObject)
        {
            _provider.SetState(GameState.Dead);
        }
    }
}