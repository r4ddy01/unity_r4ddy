using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class Skin_Controll : MonoBehaviour
{

    [Header("Componentes")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Status")]
    public int life = 3;

    [Header("Movimento")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float movex;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int jumpVer = 2;
    [SerializeField] private float trampForce = 10f;

    [Header("Repulso de Dano")]
    [SerializeField] private float forceRangeX = 1f;
    [SerializeField] private float velRangeX = 1f;
    [SerializeField] private float forceRangeY = 1f;
    [SerializeField] private float velRangeY = 1f;


    [Header("Itens")]
    public int apple = 0;
    public int kiwi = 0;
    public int banana = 0;

    [Header("Booleanos")]
    private bool canCont = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Respawn();

    }

    void Update()
    {

        if (!canCont) return; 

        if (life <= 0)
        {
            Replay();
        }

        anim.SetBool("isWalk", false);

        movex = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(speed * movex, rb.linearVelocity.y);

        if (movex > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("isWalk", true);

        }
        else if (movex <0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("isWalk", true);
        }

        if (Input.GetButtonDown("Jump") && jumpVer > 0)
        {
            Jump();
            jumpVer--;
            anim.SetBool("isWalk", false);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        anim.SetBool("isJump", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))
        {
            life--;
            rb.linearVelocity = new Vector2(forceRangeX * velRangeX, forceRangeY * velRangeY);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpVer = 2;
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!canCont) return;

        anim.SetBool("isWalk", false);
        anim.SetBool("isJump", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jump"))
        {
            Repulse();
        }
    }

    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Respawn()
    {
        StartCoroutine(goRespawn());
    }

    private IEnumerator goRespawn()
    {
        canCont = false;

        RigidbodyType2D typeOrigem = rb.bodyType;
        rb.linearVelocity = Vector2.zero;

        rb.bodyType = RigidbodyType2D.Static;

        anim.SetTrigger("isDamage");

        yield return new WaitForSeconds(0.8f);

        anim.ResetTrigger("isDamage");

        anim.Play("Idle");

        rb.bodyType = typeOrigem;
        canCont = true;
    }

    void Repulse()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, trampForce);
    }
}
