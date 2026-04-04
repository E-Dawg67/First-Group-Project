using UnityEngine;

public class managerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Enemy;
    public int enemycount = 5;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }
    
}
