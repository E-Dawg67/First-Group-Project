using UnityEngine;

public class RotateHurt : MonoBehaviour
{

    private GameObject checker;
    void Update()
    {
        transform.Rotate(0, 0, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && checker == null)
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f);
                checker = other.gameObject;
                //Replace with game over scene
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == checker)
        {
            checker = null;
        }
    }
}
