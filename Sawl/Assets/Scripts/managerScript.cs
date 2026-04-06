using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Enemy;
    public TMP_Text currentWave;
    public TMP_Text enemies;
    public GameObject bigWave, gameUI, restartScreenobj;
    public int enemycount, wave = 1;
    public GameObject[] spawns = new GameObject[14];
    private int[] waveSize = { 5, 6, 8, 11, 13, 14 };
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        currentWave.text = "Wave " + wave;
        bigWave.SetActive(true);
        bigWave.GetComponent<TMP_Text>().text = "Wave " + wave;
        Invoke("spawnWave", 4f);

    }
    void spawnWave()
    {
        bigWave.SetActive(false);
        enemycount = waveSize[wave - 1];
        for (int i = 0; i < waveSize[wave - 1];  i++)
        {
            Instantiate(Enemy, spawns[i].transform.position, Enemy.transform.rotation);
        }
        enemies.text = "Enemies: " + enemycount + "/" + waveSize[wave - 1];
    }
    public void eliminateEnemy()
    {
        enemycount--;
        enemies.text = "Enemies: " + enemycount + "/" + waveSize[wave - 1];
        if (enemycount == 0)
        {
            wave++;
            if (wave > 5)
            {
                restartScreen();
            }
            else
            {
                bigWave.SetActive(true);
                bigWave.GetComponent<TMP_Text>().text = "Wave " + wave;
                currentWave.text = "Wave " + wave;
                Invoke("spawnWave", 4f);
            }
        }
    }
    public void restartScreen()
    {
        Cursor.visible = true;
        gameUI.SetActive(false);
        restartScreenobj.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}
