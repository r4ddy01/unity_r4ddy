using UnityEngine;

public class barra_L : MonoBehaviour
{
    Rigidbody2D rb;
    float velocity = 10f;
    float moveH;
    private Vector2 movement;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveH = 1f; //mover para cima
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveH = -1f; //mover para baixo
        }
        else
        {
            moveH = 0f; //parar
        }
        rb.linearVelocityY = moveH * velocity;

        movement = new Vector2(0f, rb.linearVelocityY);
    }
}
