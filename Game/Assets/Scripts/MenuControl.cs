using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] GameObject Comenzar1;
    [SerializeField] GameObject Salir1;

    public bool empezarSelec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (empezarSelec)
            {
                Debug.Log("Funciona o no");
                Comenzar1.SetActive(true);
                Salir1.SetActive(false);
                empezarSelec = false;
            }
            else
            {
                Debug.Log("Funciona o si");
                Comenzar1.SetActive(false);
                Salir1.SetActive(true);
                empezarSelec = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (empezarSelec)
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
