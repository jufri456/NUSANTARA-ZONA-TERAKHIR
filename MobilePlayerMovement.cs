
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MobilePlayerMovement : MonoBehaviour
{
    public VirtualJoystick joystick;

    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (joystick == null) return;

        Vector2 input = joystick.InputDirection;

        Vector3 movement = new Vector3(
            input.x, 0f, input.y
        );

        controller.Move(
            movement * moveSpeed * Time.deltaTime
        );

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(
            velocity * Time.deltaTime
        );
    }
}
