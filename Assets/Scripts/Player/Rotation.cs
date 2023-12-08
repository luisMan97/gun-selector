using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotationSpeed = 500f;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (!GameManager.Instance.weaponTwoIsFired)
        {
            return;
        }
        //Debug.Log("R" + transform.rotation.y);
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
        //Debug.Log("J" + transform.rotation.y);
        /*if (transform.rotation.y >= 0)
        {
            GameManager.Instance.weaponTwoIsFired = false;
        }*/
    }
}
