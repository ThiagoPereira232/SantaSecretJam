using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Milly : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

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
        OnRun();
    }
    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    
    void OnMove()
    {
        agent.SetDestination(player.transform.position);
    }

    void OnRun()
    {
        if (player.IsRunning)
        {
            agent.speed = runSpeed;
        }
        else
        {
            agent.speed = speed;
        }
    }

    #endregion
}
