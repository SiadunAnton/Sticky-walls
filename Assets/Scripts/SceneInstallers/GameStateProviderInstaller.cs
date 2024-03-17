using Zenject;
using Domain.Interactions.Triggered;

public class GameStateProviderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGameStateProvider>().To<DeathProvider>().AsSingle();
    }
}