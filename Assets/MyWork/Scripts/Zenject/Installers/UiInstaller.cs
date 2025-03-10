using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private JoystickController joystick;
    [SerializeField] private LookController lookController;

    public override void InstallBindings()
    {
        Container.Bind<JoystickController>().FromInstance(joystick).AsSingle();
        Container.Bind<LookController>().FromInstance(lookController).AsSingle();
    }
}