using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [Header("Boundary Padding")]
    [SerializeField] float topPadding = 0.5f;
    [SerializeField] float bottomPadding = 0.5f;
    [SerializeField] float leftPadding = 0.5f;
    [SerializeField] float rightPadding = 0.5f;

    private Vector2 minBound;
    private Vector2 maxBound;

    private Vector2 _rawInput = new Vector2();

    private void Awake() 
    {
        InitBounds();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void UpdateMovement()
    {
        Vector3 moveDelta = _rawInput * moveSpeed * Time.deltaTime;
        Vector2 targetPos = transform.position + moveDelta;
        targetPos.x = Mathf.Clamp(targetPos.x, minBound.x + leftPadding, maxBound.x - rightPadding);
        targetPos.y = Mathf.Clamp(targetPos.y, minBound.y + bottomPadding, maxBound.y - topPadding);
        transform.position = targetPos;
    }

    private void OnMove(InputValue playerInput)
    {
        _rawInput = playerInput.Get<Vector2>();
    }
}
