using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider barraSalud;
    public static float health = 100;
    [SerializeField] float dps = 20;
    public static bool isDead;
    [SerializeField] float cura = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barraSalud.value = health;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Espadazo") && !isDead) // Asegúrate de que el arma del enemigo tenga esta tag
        {
            ThirdPersonController controller = GetComponent<ThirdPersonController>(); // Obtener el script

            if (controller != null) // Verifica que no sea null
            {
                controller.TakeDamage();
                health = health - dps;
                barraSalud.value = health;

                if (health <= 0)
                {
                    isDead = true; // Evita que muera varias veces
                    controller.Die();
                }
            }
        }
        if(other.gameObject.tag == "cura" && health < 100){
            health += cura;
            if(health > 100){
                health = 100;
            }
            barraSalud.value = health;
            Destroy(other.gameObject);
        }
    }

}
