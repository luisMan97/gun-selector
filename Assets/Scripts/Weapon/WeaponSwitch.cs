using System.Collections.Generic;
using System.Linq;
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
            if (GameManager.Instance.weaponOneIsTaked)
            {
                SelectWeapon();
                GameManager.Instance.openCloseBubble = selectedWeapon == 2;
            }
            else
            {
                SelectWeaponWhenFirstOneIsNotTaked();
                GameManager.Instance.openCloseBubble = selectedWeapon == 1;
            }
            
        }
       
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                child.gameObject.SetActive(selectedWeapon == i);
                i++;
            }
        }
    }

    private void SelectWeaponWhenFirstOneIsNotTaked() // TODO: - Encontrar otra manera de hacer esto, una manera más dínamica en el SelectWeapon
    {
        Transform[] childs = transform.Cast<Transform>().ToArray();
        if (selectedWeapon == 0)
        {
            childs[0].gameObject.SetActive(true);
            childs[1].gameObject.SetActive(false);
            childs[2].gameObject.SetActive(false);
        }
        else
        {
            childs[0].gameObject.SetActive(false);
            childs[1].gameObject.SetActive(false);
            childs[2].gameObject.SetActive(true);
        }
    }
}
