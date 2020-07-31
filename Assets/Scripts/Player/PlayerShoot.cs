using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Transform weaponsContainer;
    private Timer timer;
    private InputController inputController;
    Shooter[] weapons;
    Shooter activeWeapon;
    int currentWeaponIndex;
    bool canFire;

    [SerializeField]
    Transform hand;
    [SerializeField]
    float weaponSwitchTime; // TODO: alternative is to make this value to change per weapon
    private bool switching;

    public Shooter GetActiveWeapon() => activeWeapon;

    void SwitchWeapon(int direction)
    {
        if (switching) return;
        if (weapons.Length <= 1) return;

        switching = true;
        var newWeaponIndex = currentWeaponIndex + direction;
        if (newWeaponIndex > weapons.Length - 1) newWeaponIndex = 0;
        if (newWeaponIndex < 0) newWeaponIndex = weapons.Length - 1;

        canFire = false;
        timer.Add(weaponSwitchTime, () => { 
            Equip(newWeaponIndex);
            switching = false;
        });
    }

    void Equip(int weaponIndex)
    {
        print($"switch to {weaponIndex}");

        if (activeWeapon != null)
            SetWeaponActive(activeWeapon, false);

        activeWeapon = weapons[weaponIndex];
        SetWeaponActive(activeWeapon, true);
        currentWeaponIndex = weaponIndex;
        canFire = true;
    }

    private void Awake()
    {
        weaponsContainer = transform.Find("Weapons");
        timer = GameManager.GetInstance().GetTimer();
        inputController = GameManager.GetInstance().GetInputController();

        weapons = weaponsContainer.GetComponentsInChildren<Shooter>();
        foreach (var weapon in weapons)
        {
            SetWeaponActive(weapon, false);
        }

        if (weapons.Any()) Equip(0);
    }

    private void SetWeaponActive(Shooter weapon, bool active)
    {
        var parent = active ? hand : weaponsContainer;
        weapon.transform.SetParent(parent);
        weapon.gameObject.SetActive(active);
    }

    private void Update()
    {
        if (inputController.MouseWheelUp)
            SwitchWeapon(1);

        if (inputController.MouseWheelDown)
            SwitchWeapon(-1);

        if ( inputController.Fire1)
        {
            activeWeapon.Fire();
        }
    }
}
