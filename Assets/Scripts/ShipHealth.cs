using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int health = 1;

    [Header("Options")]
    [SerializeField] private bool shakeCameraOnHit = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamageDealt());
        }

        CheckForDeath();
    }

    private void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        if (shakeCameraOnHit)
        {
            VFXManager.Manager.PlayCameraShake();
        }
    }

    private void CheckForDeath()
    { 
        if (health <= 0)
        {
            VFXManager.Manager.PlayShipExplosion(transform.position);
            Destroy(gameObject);
        }
    }
}
