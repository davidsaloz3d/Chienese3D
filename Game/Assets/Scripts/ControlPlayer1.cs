using UnityEngine;

public class ControlPlayer1 : MonoBehaviour
{
    CharacterController player;
    [SerializeField] float speed = 10,
                           jump  = 10,
                           gravity = -9.81f;

    Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.z = Input.GetAxis("Vertical") * speed;
        
        //Transformo la dirección a ejes locales del personaje
        movement = transform.TransformDirection(movement);
        
        if (Input.GetKeyDown(KeyCode.Space) 
            && onGround()){
            movement.y = jump; 
        }
         
        if (!onGround()){
            movement.y += gravity * Time.deltaTime;
        } 
         
        player.Move(movement * Time.deltaTime);        
    }

    bool onGround(){
       return Physics.Raycast(transform.position,
                              Vector3.down,
                              1.3f); 
    }
}
