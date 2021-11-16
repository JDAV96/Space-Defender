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
                DontDestroyOnLoad(_SFXInstace.gameObject);
            }

            return _SFXInstace;
        }
    }

    [Header("Shooting")]
    [SerializeField] private AudioClip basicLaserShotClip;
    [SerializeField] [Range(0f, 1f)] float basicLaserShotClipVol;

    [Header("Damage Clips")]
    [SerializeField] private AudioClip enemyExplosion;
    [SerializeField] [Range(0f, 1f)] float enemyExplosionVol;
    [SerializeField] private AudioClip playerExplosion;
    [SerializeField] [Range(0f, 1f)] float playerExplosionVol;
    [SerializeField] private AudioClip playerTookDamageClip;
    [SerializeField] [Range(0f, 1f)] float playerTookDamageVol;

    public void PlayBasicLaserShotClip()
    {
        PlayAudioClip(basicLaserShotClip, basicLaserShotClipVol);
    }

    public void PlayEnemyExplosionClip()
    {
        PlayAudioClip(enemyExplosion, enemyExplosionVol);
    }

    public void PlayPlayerExplosionClip()
    {
        
        PlayAudioClip(playerExplosion, playerExplosionVol);
    }

    public void PlayplayerTookDamageClip()
    {
        PlayAudioClip(playerTookDamageClip, playerTookDamageVol);
    }

    private void PlayAudioClip(AudioClip clip, float vol)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, vol);
        }
    }
}
