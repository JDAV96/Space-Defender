using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager _SFXInstace;

    public static SFXManager SFXInstance
    {
        get 
        {
            if (_SFXInstace == null)
            {
                _SFXInstace = Instantiate(Resources.Load<SFXManager>("SFXManager"));
            }

            return _SFXInstace;
        }
    }

    [Header("Shooting")]
    [SerializeField] private AudioClip basicLaserShotClip;
    [SerializeField] [Range(0f, 1f)] float basicLaserShotClipVol;

    [Header("Damage Clips")]
    [SerializeField] private AudioClip enemyExplosion;
    [SerializeField] [Range(0f, 1f)] float enemyExplosionpVol;
    [SerializeField] private AudioClip playerExplosion;
    [SerializeField] [Range(0f, 1f)] float playerExplosionpVol;
    [SerializeField] private AudioClip playerTookDamageClip;
    [SerializeField] [Range(0f, 1f)] float playerTookDamageVol;

    public void PlayBasicLaserShotClip()
    {
        if (basicLaserShotClip != null)
        {  
            AudioSource.PlayClipAtPoint(basicLaserShotClip, Camera.main.transform.position, basicLaserShotClipVol);
        }
    }

    public void PlayEnemyExplosionClip()
    {
        if (enemyExplosion != null)
        {  
            AudioSource.PlayClipAtPoint(enemyExplosion, Camera.main.transform.position, enemyExplosionpVol);
        }
    }

    public void PlayPlayerExplosionClip()
    {
        if (playerExplosion != null)
        {  
            AudioSource.PlayClipAtPoint(playerExplosion, Camera.main.transform.position, playerExplosionpVol);
        }
    }

    public void PlayplayerTookDamageClip()
    {
        if (playerTookDamageClip != null)
        {  
            AudioSource.PlayClipAtPoint(playerTookDamageClip, Camera.main.transform.position, playerTookDamageVol);
        }
    }
}
