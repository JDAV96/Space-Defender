using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : ShipHealth
{
    [SerializeField] int scoreValue = 10;

    protected override void OnDead()
    {
        base.OnDead();
        SFXManager.SFXInstance.PlayEnemyExplosionClip();
        ScoreKeeper.ScoreKeeperInstance.PlayerDestroyedEnemy(scoreValue);
    }
}
