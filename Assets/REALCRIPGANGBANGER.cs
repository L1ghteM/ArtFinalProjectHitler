using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REALCRIPGANGBANGER : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isOnGround = true;
    public bool gun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }else if(horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            animator.SetBool("isOnGround", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun = true;
            animator.SetBool("gun", true);
        }
        else
        {
            gun = false;
            animator.SetBool("gun", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isOnGround", true);
        }
    }
}
