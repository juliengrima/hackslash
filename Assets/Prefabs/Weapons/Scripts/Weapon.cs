using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    #region Champs
    // Ajoutez d'autres attributs spécifiques de l'arme ici
    [Header("Fields")]
    [SerializeField] private int _weaponIndex; // Index de l'arme
    [SerializeField] private int _maxAmmo; // Nombre maximum de munitions

    private int currentAmmo; // Munitions actuelles

    public int WeaponIndex { get => _weaponIndex; set => _weaponIndex = value; }

    #endregion
    #region Unity LifeCycle
    private void Reset()
    {
        _maxAmmo = 100;
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentAmmo = _maxAmmo; // Commencez avec le nombre maximum de munitions
    }
    #endregion
    #region Methods
    public int GetWeaponIndex()
    {
        return WeaponIndex;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }

    public void ReloadAmmo(int _maxAmmo)
    {
        currentAmmo = _maxAmmo; // Rechargez les munitions
    }
    #endregion
    #region Coroutines
    #endregion
}
