using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = 0.5f;
    private Vector3 _initialPosition;

    private void Awake() 
    {
        _initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shaking());
    }

    public IEnumerator Shaking()
    {
        float timeElapsed = 0;
        while (timeElapsed < shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)(Random.insideUnitCircle *shakeMagnitude);
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
