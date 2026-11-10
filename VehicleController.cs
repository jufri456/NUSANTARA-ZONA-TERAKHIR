
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float acceleration = 15f;
    public float steering = 80f;
    public float maxSpeed = 25f;

    private float currentSpeed;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        currentSpeed = Mathf.Clamp(
            currentSpeed + move * acceleration * Time.deltaTime,
            -maxSpeed,
            maxSpeed
        );

        transform.Translate(
            Vector3.forward * currentSpeed * Time.deltaTime
        );

        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            transform.Rotate(
                Vector3.up * turn * steering *
                Time.deltaTime *
                Mathf.Sign(currentSpeed)
            );
        }
    }
}
