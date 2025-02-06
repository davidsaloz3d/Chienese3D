using System;
using Unity.VisualScripting;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    public static bool bebiendo = false;
    public static int botellas = 0;
    public static bool invisible = false;
    private float tiempoRestante = 0f;
    
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
                tiempoRestante = 10f;
                Invoke("NoBebe", 1f);
                Debug.Log("Bebiendo");
            }
        }

        if(invisible){
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                invisible = false;
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
            Destroy(other.gameObject);
        }
    }

    public void NoBebe(){
        bebiendo = false;
        Debug.Log("Ahora");
    }
}
