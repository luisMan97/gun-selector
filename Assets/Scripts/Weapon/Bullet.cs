using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DestroyEnemy(collision.gameObject);
    }

    private void DestroyEnemy(GameObject gameObject)
    {
        if (gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}