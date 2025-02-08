using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject menuPausa;

    [SerializeField] GameObject volver;
    [SerializeField] GameObject salir;

    public bool volverSelec = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (volverSelec)
            {
                Debug.Log("Funciona o no");
                volver.SetActive(false);
                salir.SetActive(true);
            }
            else
            {
                volver.SetActive(true);
                salir.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (volverSelec)
            {
                menuPausa.SetActive(false);
                
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
        Debug.Log("Funciona");
        Time.timeScale = 1;
    }

    public void Salir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");

    }
}
