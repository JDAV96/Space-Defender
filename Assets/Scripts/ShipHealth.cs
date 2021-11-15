using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int Health = 1;

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
        Health -= damageToTake;
    }

    private void CheckForDeath()
    { 
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
