//------------------------------------------------------------
//
// Adventure 3D - Open world game
// Copyright © 2024 João Ferreira & Hugo Guimaraães. All rights reserved.
// 
// This is a game based on the Unity Engine. A project for a university subject.
// University: Insituto Politécnico de Viana do Castelo
//
//------------------------------------------------------------
using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        if(agent) {
            if(Vector3.Distance(player.position, agent.transform.position) > 10.0f) {
                transform.position = player.position;
            }

            agent.SetDestination(player.position);
        }        
    }
}
