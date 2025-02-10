using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject CanvaPrincipal;

    [SerializeField] GameObject Textaco;

    [SerializeField] GameObject m1;
    [SerializeField] GameObject m2;
    [SerializeField] GameObject m3;
    [SerializeField] GameObject m4;
    [SerializeField] GameObject m5;
    [SerializeField] GameObject m6;
    [SerializeField] GameObject m7;

    public int mensaje = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(mensaje == 1){
                m1.SetActive(false);
                m2.SetActive(true);
                mensaje = 2;
            }else if(mensaje == 2){
                m2.SetActive(false);
                m3.SetActive(true);
                mensaje = 3;
            }else if(mensaje == 3){
                m3.SetActive(false);
                m4.SetActive(true);
                mensaje = 4;
            }else if(mensaje == 4){
                m4.SetActive(false);
                m5.SetActive(true);
                mensaje = 5;
            }else if(mensaje == 5){
                m5.SetActive(false);
                m6.SetActive(true);
                mensaje = 6;
            }else if(mensaje == 6){
                m6.SetActive(false);
                m7.SetActive(true);
                mensaje = 7;
            }else if(mensaje == 7){
                m7.SetActive(false);
                CanvaPrincipal.SetActive(true);
                Textaco.SetActive(false);
                mensaje = 1;
                Time.timeScale = 1;
                Invoke("PalJuego", 2);
            }
            
        }
    }

    void PalJuego(){
        SceneManager.LoadScene("Level1");
    }
}
