using System;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                target = hit.point;
                agent.SetDestination(target);
            }
        }
    }
}
