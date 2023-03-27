using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, points.Length);
        agent.SetDestination(points[rand].position);

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            int rand = Random.Range(0, points.Length);
            agent.SetDestination(points[rand].position);
        }
    }
}
