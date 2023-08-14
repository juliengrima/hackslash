using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Mouse : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] InputActionReference _mouseWheel;
    [SerializeField] InputActionReference _keys;
    [SerializeField] InputActionReference _look;
    [Header("Componenents")]
    [SerializeField] Rigidbody2D _rb; // Appel du RigidBody du GameObject
    [SerializeField] Inventory _inventory; // Référence au script Inventory
    [SerializeField] Transform _weaponSpawner;

    private int selectedWeaponIndex = 0; // Index de l'arme sélectionnée
    //bool _isButtonPressed = _keys.action.IsPressed();
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        GetNextWeapon();
    }

    private void MouseLook()
    {
        //throw new NotImplementedException();
        Vector2 direction = _look.action.ReadValue<Vector2>();
        // Récupérer la position de la souris dans l'espace de jeu
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //// Calculer la direction vers la position de la souris
        Vector2 lookDirection = direction - _rb.position;

        //// Calculer l'angle de rotation en radians
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //// Créer une nouvelle rotation en utilisant l'angle calculé
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        // Appliquer la rotation au RigidBody
        _rb.MoveRotation(rotation);
    }

    private void GetNextWeapon()
    {
        //throw new NotImplementedException();
        Vector2 selection = _mouseWheel.action.ReadValue<Vector2>();
        // Gérer le changement d'arme en fonction du défilement de la molette
        if (selection.y > 0)
        {
            selectedWeaponIndex++;
            if (selectedWeaponIndex >= _inventory.Weapons.Count)
            {
                selectedWeaponIndex = 0;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner.position, Quaternion.identity);
            }
        }
        else if (selection.y < 0)
        {
            selectedWeaponIndex--;
            if (selectedWeaponIndex < 0)
            {
                selectedWeaponIndex = _inventory.Weapons.Count - 1;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner.position, Quaternion.identity);
            }
        }

        // Mettre à jour l'arme actuellement sélectionnée dans l'inventaire
        _inventory.SelectedWeaponIndex = selectedWeaponIndex;
    }
}
