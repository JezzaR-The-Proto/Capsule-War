using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour {

    private NavMeshAgent nav;
    private Transform player;
    private Vector3 PlayerPos;

    void Start () {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () { 
        PlayerPos = player.position;
        Debug.Log(PlayerPos);
        nav.SetDestination(PlayerPos);
    }
}