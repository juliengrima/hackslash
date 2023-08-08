using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] InputActionReference _shoot;
    [SerializeField] CursorPosition _aimCursor; // AIM CURSOR POINT
    [SerializeField] float _fireRate; 
    [SerializeField] BulletDirection _bd;
    [SerializeField] Transform _spawnPoint;

    Coroutine ShootRoutine { get; set; }

    private void Start()
    {
        _shoot.action.started += ShootStart;
        _shoot.action.canceled += ShootStop;
    }

    private void ShootStart(InputAction.CallbackContext obj)
    {
        if (ShootRoutine != null) return;
        ShootRoutine = StartCoroutine(Shoot());
        IEnumerator Shoot()
        {
            var waiter = new WaitForSeconds(_fireRate);
            while (true)
            {
                Instantiate(_bd, _spawnPoint.position, Quaternion.identity).SetDirection(_aimCursor);
                yield return waiter;
            }
        }   
    }

    private void ShootStop(InputAction.CallbackContext obj)
    {
        if (ShootRoutine == null) return;
        StopCoroutine(ShootRoutine);
        ShootRoutine = null;
    } 
}
