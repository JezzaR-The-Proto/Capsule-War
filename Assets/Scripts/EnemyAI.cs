using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour {

    private NavMeshAgent nav;
    private Transform player;
    private Transform enemyTransform;
    private Vector3 PlayerPos;
    private Vector3 EnemyPos;

    void Start () {
        nav = GetComponent<NavMeshAgent>();
        enemyTransform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () { 
        PlayerPos = player.position;
        EnemyPos = enemyTransform.position;
        float dist = Vector3.Distance(EnemyPos, PlayerPos);
        Vector3 targetDirection = PlayerPos - EnemyPos;
        float singleStep = 50f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(enemyTransform.forward, targetDirection, singleStep, 0.0f);
        newDirection.y = 0f;
        if (dist > 5f) {
            nav.SetDestination(PlayerPos);
        } else {
            nav.SetDestination(EnemyPos);
            enemyTransform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}