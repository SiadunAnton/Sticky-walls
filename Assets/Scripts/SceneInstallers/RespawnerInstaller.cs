using UnityEngine;
using Zenject;

public class RespawnerInstaller : MonoInstaller
{
    [SerializeField] private Respawner _respawner;

    public override void InstallBindings()
    {
        Container.Bind<Respawner>().FromInstance(_respawner).AsSingle();
    }
}