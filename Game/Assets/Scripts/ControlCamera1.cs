using UnityEngine;

public class ControlCamera1 : MonoBehaviour
{
    [SerializeField] float sensitivity = 1;
    [SerializeField] Transform player;
    [SerializeField] Transform target;
    float mouseX, mouseY; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -45, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        player.rotation = Quaternion.Euler(0,mouseX,0); 

    }

}
