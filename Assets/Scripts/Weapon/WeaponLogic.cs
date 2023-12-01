using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float showRateTime = 0;

    void Update()
    {
        GenerateBullet();
    }

    private void GenerateBullet()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > showRateTime)
        {
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            showRateTime = Time.time + shotRate;
            Destroy(newBullet, 5);
        }
    }
}