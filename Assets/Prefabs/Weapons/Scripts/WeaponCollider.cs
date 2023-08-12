using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponCollider : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _gameObject;
    [SerializeField] UnityEvent _onPicked;

    int _maxAmmo;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var weapon = gameObject.GetComponentInParent<Weapon>();
            var weapons = _gameObject.GetComponent<inventory>();

            //IList list = weapons.Weapons;
            for (int i = 0; i < weapons.Weapons.Count; i++)
            {
                int weaponsIndex = weapons.Weapons.Count;
                if (weapons.Weapons[weaponsIndex])
                {
                    if (weaponsIndex == weapon.GetWeaponIndex())
                    {
                        weapon.ReloadAmmo(_maxAmmo);
                        _onPicked.Invoke();
                    }
                    else
                    {
                        weapons.AddWeapon(weapon);
                        _onPicked.Invoke();
                    }
                } 
            } 
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
