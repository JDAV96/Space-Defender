using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int health = 1;

    [Header("Options")]
    [SerializeField] private bool isPlayerShip = false;

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
        if (isPlayerShip)
        {
            SFXManager.SFXInstance.PlayplayerTookDamageClip();
            VFXManager.VFXInstance.PlayCameraShake();
        }
    }

    private void CheckForDeath()
    { 
        if (health <= 0)
        {
            if(isPlayerShip)
            {
                SFXManager.SFXInstance.PlayPlayerExplosionClip();
            }
            else
            {
                SFXManager.SFXInstance.PlayEnemyExplosionClip();
            }
            
            VFXManager.VFXInstance.PlayShipExplosion(transform.position);
            Destroy(gameObject);
        }
    }
}
