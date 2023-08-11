using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inventory : MonoBehaviour
{
    #region Champs
    [SerializeField] List<Weapon> weapons = new List<Weapon>(); // Liste d'armes
    [SerializeField] List<Key> keys = new List<Key>(); // Liste de clés

    public List<Weapon> Weapons { get => weapons; set => weapons = value; }
    public List<Key> Keys { get => keys; set => keys = value; }

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
            Weapons.Add(weapon);
        }
    }

    public void RemoveWeapon(Weapon weapon)
    {
        Weapons.Remove(weapon);
    }

    public bool HasWeapon(Weapon weapon)
    {
        return Weapons.Contains(weapon);
    }

    public bool HasWeaponWithIndex(int weaponIndex)
    {
        foreach (var weapon in Weapons)
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
        Keys.Add(key);
    }

    public void RemoveKey(Key key)
    {
        Keys.Remove(key);
    }

    public bool HasKey(Key key)
    {
        return Keys.Contains(key);
    }

    #endregion
    #region Coroutines
    #endregion
}