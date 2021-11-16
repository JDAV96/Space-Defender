using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipHealth : ShipHealth
{
    protected override void TakeDamage(int damageToTake)
    {
        base.TakeDamage(damageToTake);
        SFXManager.SFXInstance.PlayplayerTookDamageClip();
        VFXManager.VFXInstance.PlayCameraShake();
    }

    protected override void OnDead()
    {
        base.OnDead();
        SFXManager.SFXInstance.PlayPlayerExplosionClip();
    }
}
