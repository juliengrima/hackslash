using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Mouse : MonoBehaviour
{
    [SerializeField] InputActionReference _look;
    [SerializeField] Rigidbody2D _rb; // Appel du RigidBody du GameObject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
