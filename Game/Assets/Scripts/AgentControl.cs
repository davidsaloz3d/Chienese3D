using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    NavMeshAgent agent;

    public bool HaMuerto = false;

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
    public static float health = 100;
    [SerializeField] float dps = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
            
        agent = GetComponent<NavMeshAgent>();

        agent.destination = path[goal].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HaMuerto)
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

    }

    void ActivaCollider()
    {
        espada.enabled = true;
    }

    void DesactivaCollider()
    {
        espada.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flecha"))
        {
            anim.SetBool("Morido", true);
            agent.isStopped = true;
            HaMuerto = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Arco"))
        {
            Debug.Log("eei");
            anim.SetTrigger("Auch");
            agent.isStopped = true;
            health = health - dps;

            if (health <= 0)
            {
                anim.SetBool("Morido", true);
                agent.isStopped = true;
                HaMuerto = true;
            }
        }
    }
}
