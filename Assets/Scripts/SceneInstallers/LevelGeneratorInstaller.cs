using UnityEngine;
using Zenject;

public class LevelGeneratorInstaller : MonoInstaller
{
    [SerializeField] private LevelGenerator _generator;

    public override void InstallBindings()
    {
        Container.Bind<LevelGenerator>().FromInstance(_generator).AsSingle();
    }
}