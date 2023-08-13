using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShoot : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [Header("Cursor")]
    [SerializeField] InputActionReference _shoot;
    [SerializeField] CursorPosition _aimCursor; // AIM CURSOR POINT
    [Header("Bullet")]
    [SerializeField] BulletDirection _bulletPrefab;
    [SerializeField] Transform _bulletSpawner;
    [Header("Inventory")]
    [SerializeField] Inventory _inventory;
    [Header("Fields")]
    [SerializeField] float _fireRate;

    Weapon weapon; // Référence au script Weapon
    Coroutine ShootRoutine { get; set; }
    #endregion
    #region Unity LifeCycle
    private void Start()
    {
        int weaponIndex = weapon.WeaponIndex;

        foreach (var index in _inventory.Weapons)
        {
            if (weaponIndex == index.WeaponIndex)
            {
                //throw new NotImplementedException();
            }
        }

        _shoot.action.started += ShootStart;
        _shoot.action.canceled += ShootStop;
    }
    #endregion
    #region Methods
    private void ShootStart(InputAction.CallbackContext obj)
    {
        if (ShootRoutine != null) return;
        ShootRoutine = StartCoroutine(Shoot());
        IEnumerator Shoot()
        {
            var waiter = new WaitForSeconds(_fireRate);
            while (true)
            {
                if(weapon.GetCurrentAmmo() > 0) // Vérifier s'il y a des munitions
                {
                    Instantiate(_bulletPrefab, _bulletSpawner.position, Quaternion.identity).SetDirection(_aimCursor);
                    weapon.UseAmmo(); // Déduire une munition
                }
                yield return waiter;
            }
        }
    }

    private void ShootStop(InputAction.CallbackContext obj)
    {
        if (ShootRoutine == null) return;
        StopCoroutine(ShootRoutine);
        ShootRoutine = null;
    }

    #endregion
}
