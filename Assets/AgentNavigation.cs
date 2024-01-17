using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class AgentNavigation : MonoBehaviour
{
    [HideInInspector] public GameObject chemin;
    int currentIndex = 0;

    NavMeshAgent agent;
    PlayerStats stats;
    // Update is called once per frame

    Vector3 GetPositionFromTargetIndex(int index)
    {
        return chemin.transform.GetChild(index).position;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetPositionFromTargetIndex(currentIndex);
        stats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {

        bool hasArrived = Vector3.Distance(transform.position, GetPositionFromTargetIndex(currentIndex)) < 2;
        if (hasArrived)
        {
            currentIndex += 1;
            if(currentIndex == chemin.transform.childCount)
            {
                GetComponent<Enemy>().Die();
                stats.GetComponent<PlayerStats>().Lives -= 1;
            }
            else
            {
                agent.destination = GetPositionFromTargetIndex(currentIndex);
            }
        }
    }
}
