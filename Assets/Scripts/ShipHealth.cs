using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipHealth : MonoBehaviour
{
    [SerializeField] protected int health = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamageDealt());
        }

        CheckForDeath();
    }

    protected virtual void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
    }

    private void CheckForDeath()
    { 
        if (health <= 0)
        {
            OnDead();
            Destroy(gameObject);
        }
    }

    protected virtual void OnDead()
    {
        VFXManager.VFXInstance.PlayShipExplosion(transform.position);
    }
}
