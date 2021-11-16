using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 scrollSpeed = new Vector2(5f, 5f);
    private Material _spriteMaterial;

    private void Awake() 
    {
        _spriteMaterial = GetComponent<SpriteRenderer>().material;   
    }

    void Update()
    {
        _spriteMaterial.mainTextureOffset += scrollSpeed * Time.deltaTime;
    }
}
