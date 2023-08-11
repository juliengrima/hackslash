using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _gameObject;
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
            int weapon = gameObject.GetComponentInParent<Weapon>().WeaponIndex;
            var weapons = _gameObject.GetComponent<inventory>();

            foreach (int weaponsIndex in weapons.Weapons)
            {
                if (weapons.Weapons[weaponsIndex])
                {
                    if (weaponsIndex == weapon)
                    {

                    }
                }
            }
            
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
