using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCP : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimento;
    public bool isGrounded;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovimento(InputAction.CallbackContext value) 
    {
        movimento = value.ReadValue<Vector2>();
    }

    public void SetPular(InputAction.CallbackContext value) 
    {
        if (isGrounded) 
        {
            rb.AddForce(Vector3.up * 10);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(movimento.x, 0, movimento.y) * Time.fixedDeltaTime * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
