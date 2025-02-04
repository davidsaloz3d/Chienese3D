using UnityEngine;

public class ProyecControl : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float power = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = false;
        Invoke("Disparo", 0.4f);
        
    }

    void BorrarBolas(){
        Destroy(gameObject);
    }

    void Disparo(){
        rb.useGravity = true;
        rb.AddForce(transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);

        Invoke("BorrarBolas", 2);
    }

}
