using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Invisible : MonoBehaviour
{
    public static bool bebiendo = false;
    public static int botellas = 0;
    public static bool invisible = false;
    private float tiempoRestante = 0f;
    [SerializeField] Slider tiempoPocion;
    [SerializeField] TMP_Text botellasN;
    [SerializeField] GameObject panel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Botellas" + botellas);
        if(!bebiendo && botellas > 0 && !invisible){
            if(Input.GetMouseButton(1)){
                bebiendo = true;
                invisible = true;
                botellas--;
                botellasN.text = "x" + botellas;
                tiempoRestante = 15f;
                Invoke("NoBebe", 1f);
                Debug.Log("Bebiendo");
            }
        }

        if(invisible){
            panel.SetActive(true);
            tiempoPocion.value = tiempoRestante;
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                invisible = false;
                panel.SetActive(false);
            }
            Debug.Log("Invisible" + tiempoRestante);
        }
    }

    private void Invoke(string v1, int v2, float v3)
    {
        throw new NotImplementedException();
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Potion")){
            botellas++;
            botellasN.text = "x " + botellas;
            Destroy(other.gameObject);
        }
    }

    public void NoBebe(){
        bebiendo = false;
        Debug.Log("Ahora");
    }
}
