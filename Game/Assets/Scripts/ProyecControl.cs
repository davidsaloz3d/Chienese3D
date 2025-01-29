using UnityEngine;

public class ProyecControl : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float power = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 

        rb.AddForce(transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);

        Invoke("BorrarBolas", 2);
    }

    void BorrarBolas(){
        Destroy(gameObject);
    }

}
