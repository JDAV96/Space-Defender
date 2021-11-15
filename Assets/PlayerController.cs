using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Vector2 _rawInput = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector3 moveDelta = _rawInput * moveSpeed * Time.deltaTime;
        transform.position += moveDelta;
    }

    private void OnMove(InputValue playerInput)
    {
        _rawInput = playerInput.Get<Vector2>();
    }
}
