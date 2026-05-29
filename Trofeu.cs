using UnityEngine;
using UnityEngine.SceneManagement;

public class Troféu : MonoBehaviour
{
    private string nextFase = "Fase2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skin"))
        {
            NextFase();
        }
    }

    void NextFase()
    {
        SceneManager.LoadScene(nextFase);
    }
}
