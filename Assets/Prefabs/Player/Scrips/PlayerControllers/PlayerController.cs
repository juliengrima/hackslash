using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _move;

    [SerializeField] float _speed;

    public static PlayerController Instance 
    { 
        get; private set; 
    }   

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("OMG");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();
        _rb.velocity = direction * _speed;
    }
}
