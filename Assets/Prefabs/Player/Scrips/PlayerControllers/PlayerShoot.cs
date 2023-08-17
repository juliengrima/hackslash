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
    private int selected;
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
        int nextweapon = _nextWeapon.GetNextWeapon();
        if (nextweapon > 0)
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
