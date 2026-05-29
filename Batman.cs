using Unity.VisualScripting;
using UnityEngine;

public class Batman : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 4f;
    bool goRight;
    public Transform pontoA;
    public Transform pontoB;
    public float vel = 2f;
    public bool goRght = true;
    public float passTime;
    public AudioClip dano;
    [Range(0f, 1f)] public float vol = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = pontoA.position;
        if (pontoA == null || pontoB == null) return;
    }

    private void Update()
    {
        passTime += Time.deltaTime * vel;

        if (goRght)
        {
            transform.position = Vector2.Lerp(pontoA.position, pontoB.position, passTime);

            if (passTime >= 1)
            {
                passTime = 0;
                goRght = false;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(pontoB.position, pontoA.position, passTime);
            if (passTime >= 1)
            {
                passTime = 0;
                goRght = true;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Skin"))
        {
            collision.GetComponent<Skin_Controll>().life--;

            AudioSource.PlayClipAtPoint(dano, transform.position, vol);
        }
    }
}
