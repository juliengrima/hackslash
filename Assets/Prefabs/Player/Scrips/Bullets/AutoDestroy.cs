using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoDestroy : MonoBehaviour
{ 
    float _startLife;
    [SerializeField] float _timelife;
    [SerializeField] float _timeCollision;
    [SerializeField] UnityEvent _effect;
    [SerializeField] UnityEvent _onStart;
    [SerializeField] Collider2D _collider2D;

    private void Start()
    {
        _startLife = Time.time;
        _onStart.Invoke();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _effect.Invoke();

       
        if (_timeCollision > _startLife)
        {
            return;
        }
        else
        {
            //if (Time.time > _startLife + _timeCollision)
            //{
            //    _collider2D.enabled = false;
            //}

            if (Time.time > _startLife + _timelife)
            {

                Destroy(gameObject);
            }
        }
        
    }
}
