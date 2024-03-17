using UnityEngine;
using Zenject;
using Domain.Interactions.Triggered;

public class DeathSeeker : MonoBehaviour
{
    private IGameStateProvider _provider;

    [Inject]
    public void Initialize(IGameStateProvider provider)
    {
        _provider = provider;
    }

    void Start()
    {
        _provider.OnStateChanged += ShowMessage;
    }

    public void ShowMessage(GameState state)
    {
        Debug.Log("Player is dead");
    }
}
