using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    [SerializeField] private Health _health;

    public override void InstallBindings()
    {
        Container.Bind<Health>().FromInstance(_health).AsSingle();
    }
}