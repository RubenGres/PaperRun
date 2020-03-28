using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    public Transform player;
    NavMeshAgent zombieAgent;
    Vector3 destination;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieAgent = GetComponent<NavMeshAgent>();
        destination = zombieAgent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        destination = player.position;
        zombieAgent.SetDestination(destination);
    }
}