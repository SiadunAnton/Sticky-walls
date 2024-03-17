using UnityEngine;
using Zenject;
using Domain.Movement;
using Domain.Interactions.Triggered;
using System;

public class Respawner : MonoBehaviour
{
    public Vector3 SpawnPosition;
    public event Action<Vector3> OnRespawned;

    private MainCharacter _character;
    private IGameStateProvider _provider;

    [Inject]
    public void Initialize(MainCharacter character, IGameStateProvider provider)
    {
        _character = character;
        _provider = provider;
    }

    private void Start()
    {
        _provider.OnStateChanged += x =>
            {
                if (x != GameState.Dead)
                    return;
                Respawn();
                OnRespawned?.Invoke(SpawnPosition);
            };
    }

    public void Respawn()
    {
        _character.gameObject.SetActive(false);
        _character.transform.position = SpawnPosition;
        _character.gameObject.SetActive(true);
    }
}
