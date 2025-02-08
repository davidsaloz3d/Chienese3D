using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject menuPausa;

    [SerializeField] GameObject volver1;
    [SerializeField] GameObject salir1;

    public bool volverSelec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volverSelec = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (volverSelec)
            {
                Debug.Log("Funciona o no");
                volver1.SetActive(true);
                salir1.SetActive(false);
                volverSelec = false;
            }
            else
            {
                Debug.Log("Funciona o si");
                volver1.SetActive(false);
                salir1.SetActive(true);
                volverSelec = true;
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

}
