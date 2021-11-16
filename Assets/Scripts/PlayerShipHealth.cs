using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipHealth : ShipHealth
{
    private int totalHealth;

    private void Awake() 
    {
        HUD.HUDInstance.SetHealthSlider(health);
        totalHealth = health;
    }

    protected override void TakeDamage(int damageToTake)
    {
        base.TakeDamage(damageToTake);
        HUD.HUDInstance.SetHealthSlider((float)health/totalHealth);
        SFXManager.SFXInstance.PlayplayerTookDamageClip();
        VFXManager.VFXInstance.PlayCameraShake();
    }

    protected override void OnDead()
    {
        base.OnDead();
        SFXManager.SFXInstance.PlayPlayerExplosionClip();
    }
}
