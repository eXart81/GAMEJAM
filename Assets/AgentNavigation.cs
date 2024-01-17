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
    float distTruc;
    Vector3 GetPositionFromTargetIndex(int index)
    {
        return chemin.transform.GetChild(index).position + new Vector3(Random.Range(-1.5f,1.5f),0f, Random.Range(-1.5f,1.5f));
    }

    void Start()
    {
        distTruc = Random.Range(-0.5f, 0.5f);
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetPositionFromTargetIndex(currentIndex);
        stats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {

        bool hasArrived = Vector3.Distance(transform.position, GetPositionFromTargetIndex(currentIndex)) < 2 + distTruc;
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
