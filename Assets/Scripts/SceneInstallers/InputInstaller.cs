using Zenject;
using Domain.Movement.Input;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IConcreteInputSignature>().To<MobileInputSignature>().AsSingle();
        Container.Bind<IInput>().To<InputController>().FromNewComponentOnNewGameObject().AsSingle();
    }
}