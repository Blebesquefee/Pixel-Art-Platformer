using UnityEngine;

public class Player_Mvmt : MonoBehaviour
{
    // Private Field
    private bool isJumping = false;
    private bool isGrounded = true;
    private float moveSpeed = 250;
    private float jumpForce = 250;

    private int simpleAttack = 25;
    private int swordAttack = 50;
    private Vector3 velocity = Vector3.zero;

    // Public Field
    public Rigidbody2D body;
    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;
    //public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckerLeft.position, groundCheckerRight.position);
        float horizontal_mvmt = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontal_mvmt);
        Flip(body.velocity.x);
        //animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));
    }

    void MovePlayer(float horizontal_mvmt)
    {
        Vector3 targetVelocity = new Vector2(horizontal_mvmt, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            body.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
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
}
