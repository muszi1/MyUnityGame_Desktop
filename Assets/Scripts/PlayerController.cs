using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public float runSpeed;
    private float activeSpeed;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool canDoubleJump;

    public Animator anim;
    public float knockBackLenght, knockBackSpeed;
    private float knockBackCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (knockBackCounter <= 0)
        {

            activeSpeed = moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                activeSpeed = runSpeed;
            }

            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded == true)
                {
                    Jump();
                    canDoubleJump = true;

                    anim.SetBool("isDoubleJumping", false);
                }

                else
                {
                    if (canDoubleJump == true)
                    {
                        Jump();
                        canDoubleJump = false;
                    }
                    // anim.SetBool("isDoubleJumping", true); doubljump bug fixed
                    anim.SetTrigger("doDoubleJump");
                }

            }

            if (theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        } else
        {
            knockBackCounter-=Time.deltaTime;
            theRB.velocity = new Vector2(knockBackSpeed * -transform.localScale.x, theRB.velocity.y);

        }

        //handle animation
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", theRB.velocity.y);

    }
    void Jump()
    { 
        
     theRB.velocity = new Vector2(theRB.velocity.x, jumpForce); 
    
    }
    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * .5f);
        anim.SetTrigger("isKnockingBack");
        knockBackCounter = knockBackLenght;
    }
}
