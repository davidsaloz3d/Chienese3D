using UnityEngine;
using UnityEngine.Rendering;

public class AnimControl : MonoBehaviour
{
    Animator anim;
    [SerializeField] float cooldown = 1;
    float lastJump = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        if(movementX != 0 || movementZ != 0){
            anim.SetBool("isRun",true);
        }else{
            anim.SetBool("isRun",false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && (Time.time - lastJump > cooldown)){
            lastJump = Time.time;
            anim.SetTrigger("hasJump");
        }
    }
}
