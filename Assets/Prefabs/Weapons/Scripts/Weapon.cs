using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    #region Champs
    // Ajoutez d'autres attributs spécifiques de l'arme ici
    [Header("Fields")]
    [SerializeField] private int weaponIndex; // Index de l'arme
    [SerializeField] private int maxAmmo; // Nombre maximum de munitions

    private int currentAmmo; // Munitions actuelles

    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    private void Start()
    {
        currentAmmo = maxAmmo; // Commencez avec le nombre maximum de munitions
    }
    #endregion
    #region Methods
    public int GetWeaponIndex()
    {
        return weaponIndex;
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

    public void ReloadAmmo()
    {
        currentAmmo = maxAmmo; // Rechargez les munitions
    }
    #endregion
    #region Coroutines
    #endregion
}
