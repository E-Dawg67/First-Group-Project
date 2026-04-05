using UnityEngine;
using TMPro;

public class managerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Enemy;
    public TMP_Text currentWave;
    public int enemycount, wave = 1;
    public GameObject[] spawns = new GameObject[14];
    private int[] waveSize = { 5, 6, 8, 11, 13, 14 };
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        currentWave.text = "Wave " + wave;
        Invoke("spawnWave", 4f);
    }
    void spawnWave()
    {
        //get rid of wave number ui
        enemycount = waveSize[wave - 1];
        for (int i = 0; i < waveSize[wave - 1];  i++)
        {
            Instantiate(Enemy, spawns[i].transform.position, Enemy.transform.rotation);
        }
    }
    public void eliminateEnemy()
    {
        enemycount--;
        if (enemycount == 0)
        {
            wave++;
            if (wave > 5)
            {
                //Display Victory Screen!
            }
            else
            {
                currentWave.text = "Wave " + wave;
                Invoke("spawnWave", 4f);
            }
        }
    }
    
}
