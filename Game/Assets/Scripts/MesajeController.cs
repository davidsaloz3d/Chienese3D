using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MesajeController : MonoBehaviour
{
    public static int Llaves = 0;

    [SerializeField] GameObject canva;

    [SerializeField] TMP_Text llavesConseguidas;

    [SerializeField] GameObject MensajeCanva;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canva.SetActive(true);
            MensajeCanva.SetActive(false);
            Llaves++;
            llavesConseguidas.text = Llaves + " / 5";
            Time.timeScale = 1;
        }

    }
}
