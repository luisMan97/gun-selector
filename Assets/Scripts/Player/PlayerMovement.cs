using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public float jumbHeight = 3;

    bool isGrounded;
    Vector3 velocity;

    private float gravity = -9.81f;

    void Update()
    {
        SetupJump();
        SetupMovement();
        SetupGravement();
    }

    private void SetupJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumbHeight * -2 * gravity);
        }
    }

    private void SetupMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(speed * Time.deltaTime * move);
    }

    private void SetupGravement()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}