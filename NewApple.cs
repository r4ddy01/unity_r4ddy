using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Apple : MonoBehaviour
{
    Animator anim;
    [SerializeField] private AudioClip sound;
    public float time = 0.5f;
    public float time2 = 2f;
    [SerializeField] [Range(0f, 1f)] private float vol = 5f; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Skin_Controll>().apple++;

        if (collision.gameObject.tag == "Skin")
        {
            anim.SetBool("isToc", true);
            Coletar();

            StartCoroutine(Atrasar());
            Destroy(gameObject, time);
        }
    }

    IEnumerator Atrasar()
    {
        yield return new WaitForSeconds(time2);
    }

    void Coletar()
    {
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position, vol);
        }
    }
}
