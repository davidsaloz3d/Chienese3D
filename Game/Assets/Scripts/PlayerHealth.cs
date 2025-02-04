using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider barraSalud;
    public float health = 100;
    [SerializeField] float dps = 20;
    public static bool isDead;
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
    }

}
