using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    Animator animator;

    private Rigidbody2D rb;
    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        moveInput = 0;
    
        if (Input.GetKey(KeyCode.Q))
            moveInput = -1;

        if (Input.GetKey(KeyCode.D))
            moveInput = 1;

        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Sign(moveInput) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }



        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput*Speed, rb.linearVelocity.y);
    }
    
}
