using System;
using UnityEngine;
using Zenject;
using Domain.Interactions.Triggered;

public class CheckpointModificator : ReactiveComponent
{
    private LevelGenerator _generator;
    private Respawner _respawner;
    private bool _isUsed = false;

    [Inject]
    public void Initialize(LevelGenerator generator, Respawner respawner)
    {
        _generator = generator ?? throw new NullReferenceException("Level generator is empty.");
        _respawner = respawner ?? throw new NullReferenceException("Respawner is empty.");
    }

    public override void OnEnter(GameObject anObject)
    {
        if (!_isUsed)
        {
            _generator.GenerateLevelPart(transform.position);
            _respawner.SpawnPosition = transform.position + new Vector3(0.1f, 0f, 0f);
            _isUsed = true;
        }
    }
}
