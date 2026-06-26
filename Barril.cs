using TMPro;
using UnityEngine;

public class Barril : MonoBehaviour
{
    [Header("PREFAB")]
    public GameObject[] prefabs;
    public float timeLifePrefab = 4f;

    [Header("MOVIMENTO")]
    private PlayerControls controls;
    private float moveInput;
    private bool podeMover = true;
    public float speed = 5f;

    [Header("LIMITES DE MOVIMENTO")]
    [SerializeField] private Transform limLeft;
    [SerializeField] private Transform limRight;

    [Header("LIMITES DE SPAWN")]
    [SerializeField] private Transform limRS;
    [SerializeField] private Transform limLS;
    private bool autoBegin = true;
    private float timeSpawn = 2f;

    [Header("FRUITS")]
    public float fruits = 0f;
    public TextMeshProUGUI fruiText;

    void Awake()
    {
        controls = new PlayerControls();

        if (autoBegin)
        {
            InvokeRepeating(nameof(Spawnar), 0f, timeSpawn);
        }
    }

    void Start()
    {
        AtualizarScore();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<float>();

        if (podeMover)
        {
            transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, limLeft.position.x, limRight.position.x);
        transform.position = pos;
    }

    private void Spawnar()
    {
        float x = Random.Range(limLS.position.x, limRS.position.x);
        float y = 4.5f;

        GameObject prefabChoosen = prefabs[Random.Range(0, prefabs.Length)];

        Vector3 posSpawn = new Vector3(x, y, -6.8f);
        GameObject item = Instantiate(prefabChoosen, posSpawn, Quaternion.identity);

        Destroy(item, timeLifePrefab);
    }

    public void AtualizarScore()
    {
        if (fruiText != null)
        {
            fruiText.text = "Score: " + fruits.ToString();
        }
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Move.Disable();
    }
}
