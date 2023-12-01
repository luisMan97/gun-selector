using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        Debug.Log("LIIS");
        TakeWeapon(other.gameObject);
    }

    private void TakeWeapon(GameObject gameObject)
    {
        if (gameObject.CompareTag("Weapon"))
        {
            WeaponType weaponType = gameObject.GetComponent<Weapon>().weaponType;
            switch (weaponType)
            {
                case WeaponType.weaponOne:
                    GameManager.Instance.weaponOneIsTaked = true;
                    break;
                case WeaponType.weaponTwo:
                    GameManager.Instance.weaponTwoIsTaked = true;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
