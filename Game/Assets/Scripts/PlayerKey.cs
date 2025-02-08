using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public bool activado = false;
    [SerializeField] GameObject mensaje;

    [SerializeField] GameObject LlaveConseguida;

    [SerializeField] GameObject Canva;

    public bool conseguido = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activado && !conseguido)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LlaveConseguida.SetActive(true);
                Canva.SetActive(false);
                conseguido = true;
                Time.timeScale = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !conseguido)
        {
            mensaje.SetActive(true);
            activado = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);
            activado = false;
        }
    }
}
