using System.Runtime.CompilerServices;
using TMPro;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class theBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float vel = 5f;
    private Vector2 VelD;
    private float timer;
    private float VelT;
    private float ponto;
    private float ponto2;
    [SerializeField] TextMeshProUGUI pontuacao;
    [SerializeField] TextMeshProUGUI pontuacao2;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcao();
        rb.linearVelocity = VelD;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        VelT = timer;

    }
    private void direcao()
    {
        int x = Random.Range(0, 4);
        switch (x)
        {
            case 0:
                VelD = new Vector2(vel, vel);
                break;
            case 1:
                VelD = new Vector2(-vel, vel);
                break;
            case 2:
                VelD = new Vector2(vel, -vel);
                break;
            case 3:
                VelD = new Vector2(-vel, -vel);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            ponto++;
            Atualizar();

        }
        if (collision.gameObject.CompareTag("Parede2"))
        {
            ponto2++;
            Atualizar2();

        }
    }

    void Atualizar()
    {
        pontuacao.text = ponto.ToString();
    }

    void Atualizar2()
    {
        pontuacao2.text = ponto2.ToString();
    }



}

