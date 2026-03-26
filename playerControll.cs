using System.Data.SqlTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Componentes")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    [Header("Inputs")]
    [SerializeField] private float moveX;
    [SerializeField] private float moveY;

    [Header("Movimentos")]
    public float speed;
    public float jumpForce;
    public int addJumps;
    private int jumpVerify;
    public bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpVerify = addJumps;
    }

    
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else 
            {
                if (jumpVerify > 0)
                {
                    Jump();
                    jumpVerify--;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("isWalk", true);
        }
        else if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("isWalk", true);
        }

        if (moveX == 0)
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpVerify = addJumps;
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            anim.SetBool("isJump", true);
        }
    }
}
