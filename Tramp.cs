using UnityEngine;
using System.Collections;

public class Tramp : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Skin"))
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        anim.SetTrigger("isJump");
        yield return new WaitForSeconds(1f);
        anim.ResetTrigger("isJump");

        anim.Play("Idle");
    }
}
