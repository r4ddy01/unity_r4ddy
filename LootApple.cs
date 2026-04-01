using UnityEngine;

public class LootApple : MonoBehaviour
{
    private Animator exp;

    void Start()
    {
        exp = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().apple++;
            exp.SetBool("isTouch", true);

            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, 0.45f);
        }
    }
}
