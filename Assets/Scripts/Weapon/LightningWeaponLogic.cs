using System.Collections;
using UnityEngine;

public class LightningWeaponLogic : MonoBehaviour
{
    public float shotRate = 0.5f;

    private float showRateTime = 0;

    void Update()
    {
        StartCoroutine( GenerateBullet());
    }

    private IEnumerator GenerateBullet()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > showRateTime)
        {
            showRateTime = Time.time + shotRate;
            GameManager.Instance.weaponTwoIsFired = true;
            yield return new WaitForSeconds(1);
            GameManager.Instance.weaponTwoIsFired = false;
        }
    }
}
