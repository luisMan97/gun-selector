using UnityEngine;

public class TurretRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;

    void Update()
    {
        ThrowLightning();
    }

    private void ThrowLightning()
    {
        if (!GameManager.Instance.weaponTwoIsFired)
        {
            return;
        }
        float maxDistance = 30f;
        Ray ray = new(transform.position, transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, whatToDetect, QueryTriggerInteraction.Ignore))
        {
            AttractObjects(hit);
        }
    }

    private void AttractObjects(RaycastHit hit)
    {
        if (!GameManager.Instance.bubbleIsShowed)
        {
            return;
        }
        hit.transform.position = new Vector3(transform.position.x + 0.3f, hit.transform.position.y);
    }
}
