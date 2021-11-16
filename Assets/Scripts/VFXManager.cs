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

    public void PlayShipExplosion(Vector3 locationToPlay)
    {
        if (_explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(_explosionEffect, locationToPlay, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
