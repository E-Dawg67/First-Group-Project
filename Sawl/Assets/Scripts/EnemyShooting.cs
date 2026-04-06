using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    public Transform playerTarget;

    public GameObject bullet;
    public Transform firePoint, enemy;
    public float fireRate = 2f;
    public float delay = 1f;
    private NavMeshAgent agent;
    void Start()
    {
        GameObject playerObject = GameObject.Find("Sawl_Child");
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
        Invoke("Shoot", delay);
    }

    void FixedUpdate()
    {
        if (playerTarget != null)
        {
            Vector3 targetPosition = playerTarget.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            transform.Rotate(0, 90f, 0);
            agent.SetDestination(targetPosition);
        }
    }

    void Shoot()
    {
        if (playerTarget != null && bullet != null && firePoint != null)
        {
            GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.transform.LookAt(playerTarget.position);
        }
        Invoke("Shoot", fireRate);
    }
}