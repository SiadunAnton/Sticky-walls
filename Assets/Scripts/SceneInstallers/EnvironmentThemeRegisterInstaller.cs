using UnityEngine;
using Zenject;

public class EnvironmentThemeRegisterInstaller : MonoInstaller
{
    [SerializeField] private EnvironmentThemeRegister _register;

    public override void InstallBindings()
    {
        Container.Bind<EnvironmentThemeRegister>().FromInstance(_register).AsSingle();
    }
}