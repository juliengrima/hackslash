using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inventory : MonoBehaviour
{
    #region Champs
    [SerializeField] List<Weapon> weapons = new List<Weapon>(); // Liste d'armes
    [SerializeField] List<Key> keys = new List<Key>(); // Liste de clés
   
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    #endregion
    #region Methods
    public void AddWeapon(Weapon weapon)
    {
        int weaponIndex = weapon.GetWeaponIndex();
        // Vérifier si l'arme avec le même index existe déjà dans l'inventaire
        if (!HasWeaponWithIndex(weaponIndex))
        {
            weapons.Add(weapon);
        }
    }

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
    }

    public bool HasWeapon(Weapon weapon)
    {
        return weapons.Contains(weapon);
    }

    public bool HasWeaponWithIndex(int weaponIndex)
    {
        foreach (var weapon in weapons)
        {
            if (weapon.GetWeaponIndex() == weaponIndex)
            {
                return true;
            }
        }
        return false;
    }

    public void AddKey(Key key)
    {
        keys.Add(key);
    }

    public void RemoveKey(Key key)
    {
        keys.Remove(key);
    }

    public bool HasKey(Key key)
    {
        return keys.Contains(key);
    }

    #endregion
    #region Coroutines
    #endregion
}