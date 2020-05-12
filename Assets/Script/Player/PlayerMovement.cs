using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [Range(0, .5f)] [SerializeField] private float flipThreshold = .1f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 m_velocity = Vector3.zero;
    bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        float moveVertical = Input.GetAxisRaw("Vertical") * speed;
        animator.SetBool("Andando", (moveHorizontal != 0) || (moveVertical != 0));
        FlipSprite(moveHorizontal);
        Vector3 targetVelocity = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);
    }

    void FlipSprite(float horizontal)
    {
        if (horizontal < -flipThreshold)
        {
            isFlipped = true;
        }
        else if (horizontal > flipThreshold)
        {
            isFlipped = false;
        }
        spriteRenderer.flipX = isFlipped;
    }
}