using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    private static VFXManager _manager;

    public static VFXManager Manager
    {
        get 
        {
            if (_manager == null)
            {
                _manager = Instantiate(Resources.Load<VFXManager>("VFXManager"));
            }

            return _manager;
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
