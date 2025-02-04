using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] GameObject[] path;
    int goal = 0;

    [Header("Detection")]
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;

    [SerializeField] float visionArea = 10;
    [SerializeField] float AttackArea = 2.5f;
    float distance;
    bool follow = false;
    [SerializeField] float attackCooldown = 2f; // Tiempo de espera entre ataques
    private float lastAttackTime = 0f;

    [SerializeField] Collider espada;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = path[goal].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < visionArea && !PlayerHealth.isDead)
        {
            agent.destination = player.transform.position;
            anim.SetBool("Run", true);
            follow = true;
            agent.speed = 3.5f;
            if (distance < AttackArea)
            {
                if (Time.time >= lastAttackTime + attackCooldown) // Solo ataca si ha pasado el cooldown
                {
                    anim.SetBool("Attack", true);
                    agent.isStopped = true; // Se queda quieto al atacar
                    lastAttackTime = Time.time;
                    Invoke("ActivaCollider", 0.2f);
                }
            }
            else
            {
                agent.isStopped = false;
                anim.SetBool("Attack", false);
            }
        }
        else
        {
            
            agent.isStopped = false;
            agent.destination = path[goal].transform.position;
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            follow = false;
            agent.speed = 1f;
        }
        if (agent.remainingDistance < 1 && !follow)
        {
            goal++;
            if (goal == path.Length)
            {
                goal = 0;
            }
            agent.destination = path[goal].transform.position;
        }
    }

    void ActivaCollider()
    {
        Debug.Log("Activado");
        espada.enabled = true;
        Invoke("DesactivaCollider", 1.4f);
    }

    void DesactivaCollider()
    {
        Debug.Log("Desactivado");
        espada.enabled = false;
    }
}
