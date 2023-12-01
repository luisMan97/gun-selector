using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;
    public int selectedWeapon = 0;

    private List<GameObject> takedWeapons = new();

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        SetTakedWeapons();
        ChangeWeapon();
    }

    private void SetTakedWeapons()
    {
        takedWeapons = new() { weapons[0] };
        if (GameManager.Instance.weaponOneIsTaked)
        {
            takedWeapons.Add(weapons[1]);
        }
        if (GameManager.Instance.weaponTwoIsTaked)
        {
            takedWeapons.Add(weapons[2]);
        }
    }

    private void ChangeWeapon()
    {
        int previousWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= takedWeapons.Count - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = takedWeapons.Count - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if (previousWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (selectedWeapon == i)
                {
                    weapon.gameObject.SetActive(true);
                } else
                {
                    weapon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }
}
