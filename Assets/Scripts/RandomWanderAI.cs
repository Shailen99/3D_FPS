using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWanderAI : MonoBehaviour
{
  [SerializeField] private Transform[] movePositionTransform;
  private UnityEngine.AI.NavMeshAgent navMeshAgent;
  public int currentPath = 0;
    // Start is called before the first frame update
    private void Awake()
    {
      navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

      navMeshAgent.destination = movePositionTransform[currentPath].position;
      if (!navMeshAgent.pathPending)
      {
      if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
      {
          if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
          {
            if(currentPath < movePositionTransform.Length)
            {
              currentPath++;
            }
            else
            {
              currentPath = 0;
            }
          }
      }
  }
    }
}
