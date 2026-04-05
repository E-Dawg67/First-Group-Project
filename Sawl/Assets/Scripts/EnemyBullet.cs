using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * 25f;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.GetComponent<Health>();
            
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //Replace with game over scene
            }

        }
        Destroy(gameObject);
    }
}
