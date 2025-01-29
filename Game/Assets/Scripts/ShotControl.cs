using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] GameObject proyectil;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Instantiate(proyectil, transform.position, transform.rotation);
        }
    }
}
