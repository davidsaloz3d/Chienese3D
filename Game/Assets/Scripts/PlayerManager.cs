using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Slider barraSalud;
    float health = 100;
    [SerializeField] float dps = 10;

    [SerializeField] float cura = 25;

    void Start()
    {
        barraSalud.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "lava"){
            health = health - dps * Time.deltaTime;
            barraSalud.value = health;

            if(health <= 0){
                //Muere
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "cura" && health < 100){
            health += cura;
            if(health > 100){
                health = 100;
            }
            barraSalud.value = health;
            Destroy(other.gameObject);

            if(health <= 0){
                //Muere
            }
        }
    }
}
