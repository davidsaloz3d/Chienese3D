using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] GameObject[] path;
    int goal = 0;

    [Header("Detection")]
    [SerializeField] GameObject player;
    [SerializeField] float visionArea = 5;
    float distance;
    bool follow = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = path[goal].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position,player.transform.position);
        if(distance < visionArea){
            agent.destination = player.transform.position;
            follow = true;
        }else{
            agent.destination = path[goal].transform.position;
            follow = false;
        }
        if(agent.remainingDistance < 1 && !follow){
            goal++;
            if(goal == path.Length){
                goal = 0;
            }
            agent.destination = path[goal].transform.position;
        }
    }
}
