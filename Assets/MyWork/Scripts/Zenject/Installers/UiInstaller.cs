using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private JoystickController joystick;
    public override void InstallBindings()
    {
        Container.Bind<JoystickController>().FromInstance(joystick).AsSingle();
    }
}