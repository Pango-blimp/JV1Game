using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D rb;
    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = 0;
        if (Input.GetKey(KeyCode.Q))
            moveInput = -1;

        if (Input.GetKey(KeyCode.D))
            moveInput = 1;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput*Speed, rb.linearVelocity.y);
    }
    
}
