using UnityEngine;
using UnityEngine.AI;

public class NPCWalk : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] GameObject[] path;
    int goal = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = path[goal].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
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
