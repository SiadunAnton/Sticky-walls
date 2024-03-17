using Zenject;
using Domain.Services;

public class InputBindInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputControlBindService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}