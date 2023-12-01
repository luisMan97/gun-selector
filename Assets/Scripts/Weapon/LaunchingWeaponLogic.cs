using UnityEngine;

public class LaunchingWeaponLogic : MonoBehaviour
{
    public Transform objetivePoint;
    public GameObject bullet;
    public float height = 10;
    public float gravity = -9.8f;

    void Update()
    {
        GenerateBullet();
    }

    private void GenerateBullet()
    {
        if (Input.GetButtonDown("Fire1") && bullet != null && objetivePoint != null)
        {
            Rigidbody ball = bullet.GetComponent<Rigidbody>();
            Physics.gravity = Vector3.up * gravity;
            ball.useGravity = true;
            ball.velocity = CalculateInitialSpeed();
            Destroy(bullet, 5);
        }
    }

    private Vector3 CalculateInitialSpeed()
    {
        Vector3 desplazamiento = objetivePoint.position - bullet.transform.position;
        float speedY, speedX, speedZ;
        speedY = Mathf.Sqrt(-2 * gravity * height);
        speedX = desplazamiento.x / ((-speedY / gravity) + Mathf.Sqrt(2 * (desplazamiento.y - height) / gravity));
        speedZ = desplazamiento.z / ((-speedY / gravity) + Mathf.Sqrt(2 * (desplazamiento.y - height) / gravity));
        return new Vector3(speedX, speedY, speedZ);
    }
}
