using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public bool activado = false;
    [SerializeField] GameObject mensaje;

    [SerializeField] GameObject LlaveConseguida;

    [SerializeField] GameObject Canva;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LlaveConseguida.SetActive(true);
                Canva.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mensajero"))
        {
            mensaje.SetActive(true);
            activado = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mensajero"))
        {
            mensaje.SetActive(false);
            activado = false;
        }
    }
}
