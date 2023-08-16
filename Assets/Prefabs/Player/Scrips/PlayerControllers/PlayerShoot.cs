using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [Header("Cursor")]
    [SerializeField] InputActionReference _shoot;
    //[SerializeField] CursorPosition _aimCursor; // AIM CURSOR POINT
    [Header("Inventory")]
    [SerializeField] Inventory _inventory;
    [SerializeField] PlayerController_Mouse _nextWeapon;
    [Header("Fields")]

    Weapon weapon; // Référence au script Weapon
    #endregion
    #region Unity LifeCycle
    private void Start()
    {
        Armed();   
    }
    #endregion
    #region Methods
    void Armed()
    {
        if (_nextWeapon)
        {
            _shoot.action.started += weapon.ShootStart;
            _shoot.action.canceled += weapon.ShootStop;
        }
        else
        {
            return;
        }
    }
    #endregion
}
