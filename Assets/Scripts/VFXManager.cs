using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    private static VFXManager _VFXInstance;

    public static VFXManager VFXInstance
    {
        get 
        {
            if (_VFXInstance == null)
            {
                _VFXInstance = Instantiate(Resources.Load<VFXManager>("VFXManager"));
            }

            return _VFXInstance;
        }
    }

    [SerializeField] private ParticleSystem _explosionEffect;
    private CameraShake _cameraShake;

    private void Awake() 
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    public void PlayCameraShake()
    {
        if (_cameraShake != null)
        {
            _cameraShake.Play();
        }
    }

    public void PlayShipExplosion(Vector3 locationToPlay)
    {
        if (_explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(_explosionEffect, locationToPlay, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
