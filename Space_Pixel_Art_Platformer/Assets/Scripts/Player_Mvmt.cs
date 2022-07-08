using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Mvmt : MonoBehaviour
{
    // Private Field
    public bool isGrounded = true;
    private float moveSpeed = 250;
    private float jumpForce = 250;
    public bool doublejump;
    private int simpleAttack = 25;
    private int swordAttack = 50;
    private Vector3 velocity = Vector3.zero;
    private KeyCode jumpKey = KeyCode.Space;

    // Public Field
    public Rigidbody2D body;
    public Animator animator;
    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
            Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckerLeft.position, groundCheckerRight.position);
        if (isGrounded)
            doublejump = true;
        float horizontal_mvmt = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontal_mvmt);
        Flip(body.velocity.x);
    }

    private void MovePlayer(float horizontal_mvmt)
    {
        Vector3 targetVelocity = new Vector2(horizontal_mvmt, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);

        if (horizontal_mvmt == 0)
            animator.SetBool("run", false);
        else
            animator.SetBool("run", true);
    }

    private void Jump()
    {
        if (!isGrounded && doublejump)
        {
            animator.SetBool("doublejump", true);
            body.AddForce(new Vector2(0f, jumpForce));
            doublejump = false;
            StartCoroutine(ResetDoubleJumpDelay());
            Debug.Log(doublejump);
        }

        if (isGrounded)
        {
            animator.SetBool("jump", true);
            body.AddForce(new Vector2(0f, jumpForce));
            StartCoroutine(ResetJumpDelay());
            Debug.Log("Has jump");
        }
    }

    private void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
            spriteRenderer.flipX = false;
        else if (_velocity < -0.1f)
            spriteRenderer.flipX = true;
    }

    public void AddPower(int value)
    {
        simpleAttack += value;
        swordAttack += value;
    }

    IEnumerator ResetJumpDelay()
    {
        yield return new WaitForSeconds(0.5F);
        animator.SetBool("jump", false);
    }

    IEnumerator ResetDoubleJumpDelay()
    {
        yield return new WaitForSeconds(0.5F);
        animator.SetBool("doublejump", false);
    }
}
