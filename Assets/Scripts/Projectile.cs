using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileLifetime;
    [SerializeField] private Vector2 projectileVelocity;

    private void Awake() 
    {
        Destroy(gameObject, projectileLifetime);
        Rigidbody2D projectileRigidbody = GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = projectileVelocity;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, projectileVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(gameObject);       
    }
}
