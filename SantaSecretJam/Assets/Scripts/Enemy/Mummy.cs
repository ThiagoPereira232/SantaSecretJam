using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            // chegou no limite de distancia
        }
        else
        {
            // mummy anda
        }
    }
}
