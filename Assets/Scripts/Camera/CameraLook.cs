using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;

    private float xRotation = 0;

    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        setupHorizontalRotation();
        setupVerticalRotation();
    }

    private void setupHorizontalRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void setupVerticalRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}