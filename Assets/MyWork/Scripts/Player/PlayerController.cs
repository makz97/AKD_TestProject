using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 3f;

    private JoystickController joystick;
    private LookController lookController;

    [Inject]
    public void Construct(JoystickController joystick, LookController lookController)
    {
        this.joystick = joystick;
        this.lookController = lookController;
    }

    private void Start()
    {
        if (!characterController)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    private void Update()
    {
        var move = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * moveSpeed;
        characterController.SimpleMove(transform.TransformDirection(move));
    }
}