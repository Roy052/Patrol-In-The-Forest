using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool facingLeft;
    Vector2 movement;
    public Animator animator;
    private Vector3 localScale;
    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        facingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x != 0) wait = true;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (wait)
        {
            if (movement.x < 0)
                facingLeft = true;
            else if (movement.x > 0)
                facingLeft = false;

            if (((facingLeft) && (localScale.x < 0)) || ((!facingLeft) && (localScale.x > 0)))
                localScale.x *= -1;

            transform.localScale = localScale;
        }
    }
}
