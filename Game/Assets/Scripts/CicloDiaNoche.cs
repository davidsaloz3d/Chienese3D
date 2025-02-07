using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0.0f, 24f)]public float Hora = 12;
    public Transform Sol;

    private float SolX;

    public float DuracionDiaEnMinutos = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hora += Time.deltaTime * (24 / (60 * DuracionDiaEnMinutos));

        if(Hora >= 24){
            Hora = 0;
        }

        Rotacion();
    }

    void Rotacion(){
        SolX = 15 * Hora;

        Sol.localEulerAngles = new Vector3(SolX, 0, 0);

        if(Hora < 6 || Hora > 18){
            Sol.GetComponent<Light>().intensity = 0;
        }else{
            Sol.GetComponent<Light>().intensity = 1;
        }
    }
}
