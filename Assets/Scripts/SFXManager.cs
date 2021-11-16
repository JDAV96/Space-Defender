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

    private AudioSource musicSource;

    [Header("Music Files")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip endMenuMusic;

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

    private void Awake() 
    {
        musicSource = GetComponent<AudioSource>();    
    }

    public void PlayMainMenuMusic()
    {
        ChangeMusic(mainMenuMusic);
    }

    public void PlayGameMusic()
    {
        ChangeMusic(gameMusic);
    }

    public void PlayEndMenuMusic()
    {
        ChangeMusic(endMenuMusic);
    }

    private void ChangeMusic(AudioClip newMusic)
    {
        musicSource.clip = newMusic;
        musicSource.Play();
    }

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
