using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]private float huntHurtRange = 3;
    [SerializeField]private float patrolHurtRange = 5;
    NavMeshAgent agent;

    Transform player;
    [SerializeField] LayerMask groundLayer, playerLayer;
    float groundRange = 10;

    // patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;
    bool hunting = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(hunting){
            ChasePlayer();
        }
        Patrol();
    }

    void Patrol(){
        if (!walkpointSet) {
            SearchForDest();
        } else{
            agent.SetDestination(destPoint);
        }

        float hurtRange;
        if(hunting){
            hurtRange = huntHurtRange;
        } else {
            hurtRange = patrolHurtRange;
        }

        if (Vector3.Distance(transform.position, destPoint) < hurtRange)
        {
            if(hunting){
                destPoint = GetComponentInParent<Transform>().position;
                hunting = false;
            } else {
                walkpointSet = false;
            }
        }
    }

    void SearchForDest(){
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y + groundRange, transform.position.z + z);

        RaycastHit hit;
        if(Physics.Raycast(destPoint, Vector3.down, out hit,  groundLayer)){
            destPoint = hit.point;
            walkpointSet = true;
        }
    }
    
    void ChasePlayer(){
        destPoint = player.position;
    }

    public void HuntPlayer(){
        hunting = true;
        walkpointSet = true;
    }

    public bool IsHunting(){
        return hunting;
    }
}
