using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectileToShoot;
    [SerializeField] private float timeBetweenShots = 1f;

    [Header("AI Shooter")]
    [SerializeField] private bool useAI;
    [SerializeField] private float shotVariance = 0.5f;
    [SerializeField] private float minTimeBetweenShots = 0.1f;

    private Coroutine shootingCoroutine;

    private bool _isFiring;

    public bool isFiring
    {
        private get { return _isFiring; }
        set 
        { 
            _isFiring = value;
            HandleShooting();
        }
    }

    private void Start() 
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    private void HandleShooting()
    {
        if (_isFiring)
        {
            shootingCoroutine = StartCoroutine(Shoot());
        }
        else
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(projectileToShoot, gameObject.transform.position, Quaternion.identity);
            SFXManager.SFXInstance.PlayBasicLaserShotClip();
            
            if (useAI)
            {
                float nextShotInterval = Random.Range(timeBetweenShots - shotVariance, timeBetweenShots + shotVariance);
                yield return new WaitForSeconds(Mathf.Clamp(nextShotInterval, minTimeBetweenShots, float.MaxValue));
            }
            else
            {
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }

    }
}
