using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    public TMP_Text healthRemaining;


    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
   
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (gameObject.CompareTag("Player"))
        {
            healthRemaining.text = "Health: " + currentHealth;
        }
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}