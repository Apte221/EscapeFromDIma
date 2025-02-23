using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public LayerMask obstacleMask;
    public Transform[] patrolPoints;
    public float doorDetectionRadius = 2f; // Відстань для детекції дверей
    public float doorOpenDistance = 1f; // Відстань, на якій ворог може відкрити двері

    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;
    private Vector3 lastSeenPosition;
    private bool isChasing = false;
    private bool isSearching = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Перевіряємо, чи агент на NavMesh
        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Ворог не на NavMesh! Переконайся, що сцена має запечений NavMesh.");
            return;
        }
    }

    private void Update()
    {
        if (!agent.isOnNavMesh) return; // Запобігаємо помилці

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (!Physics.Raycast(transform.position, direction, distanceToPlayer, obstacleMask))
            {
                isChasing = true;
                isSearching = false;
                lastSeenPosition = player.position;
                agent.SetDestination(player.position);
            }
            else if (isChasing)
            {
                isChasing = false;
                isSearching = true;
            }
        }

        if (isSearching)
        {
            SearchLastSeenPosition();
        }
        else if (!isChasing)
        {
            Patrol();
        }

        // Перевірка на двері поблизу
        CheckForDoors();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0 || !agent.isOnNavMesh) return;

        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void SearchLastSeenPosition()
    {
        if (!agent.isOnNavMesh) return;
        agent.SetDestination(lastSeenPosition);

        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            isSearching = false;
        }
    }

    // Перевірка на наявність дверей поблизу і їх відкриття
    private void CheckForDoors()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, doorDetectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Door")) // Переконайтеся, що двері мають тег "Door"
            {
                Door_open door = collider.GetComponent<Door_open>();

                // Перевірка, чи двері ще не відкриті
                if (door != null && !door.isOpen  )
                {
                    // Перевірка, чи ворог достатньо близько до дверей для їх відкриття
                    if (Vector3.Distance(transform.position, collider.transform.position) <= doorOpenDistance)
                    {
                        // Спроба відкрити двері
                        door.TryOpen(null); // Відкриваємо двері, передаючи себе як параметр
                    }
                }
            }
        }
    }
}
