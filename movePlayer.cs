using UnityEngine;
using UnityEngine.Rendering;

public class movePlayer : MonoBehaviour
{
   

    //referencias 
    private Rigidbody2D rb;
    private Animator animPlayer;

    //movimentação
    private float movement = 0f;
    public float vel = 10f;
    private bool isf;
    public float forcaPulo = 1f;
    public Transform groundCheck;    
    public float raioCheck = 0.2f;   
    public LayerMask layerChao;     

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
           
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveH * vel, rb.linearVelocity.y);

        if (moveH > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
            animPlayer.SetBool("isWalking", true);
        }
        else if (moveH == 0)
        {
            animPlayer.SetBool("isWalking", false);
        }
        else if (moveH < 0)
        {
            transform.localScale = new Vector3(-3f, 3f, 3f);
            animPlayer.SetBool("isWalking", true);
        }

            isf = Physics2D.OverlapCircle(groundCheck.position, raioCheck, layerChao);

        if (Input.GetKeyDown(KeyCode.Space) && isf)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

   
}
