using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform playerTarget;
    public string playerTag = "Player";

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 2f;
    public float delay = 1f;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
        InvokeRepeating("Shoot", delay, fireRate);
    }

    void Update()
    {
        if (playerTarget != null)
        {
            Vector3 targetPosition = playerTarget.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }

    void Shoot()
    {
        if (playerTarget != null && bullet != null && firePoint != null)
        {
            GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.transform.LookAt(playerTarget.position);
        }
    }
}