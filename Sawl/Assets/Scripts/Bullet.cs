using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject textOBJ;
    void Update()
    {
        transform.position += transform.forward * 10f * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            /*
            TMPro.TextMeshProUGUI enemytext = GameObject.Find("EnemyCount").GetComponent<TMPro.TextMeshProUGUI>();
            GameObject.Find("GameManager").GetComponent<managerScript>().enemycount--;
            enemytext.text = GameObject.Find("GameManager").GetComponent<managerScript>().enemycount.ToString() + " Enemies Left";
            GameObject text = Instantiate(textOBJ, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), textOBJ.transform.rotation);
            text.GetComponent<TextMesh>().text = "Hit";
            text.transform.localScale *= 5f;
            Destroy(text, 2f);*/
        }
        else
        {
            /*S
            GameObject text = Instantiate(textOBJ, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f),textOBJ.transform.rotation);
            text.GetComponent<TextMesh>().text = "Miss";
            Destroy(text, 2f);
            */
        }
            Destroy(gameObject);
    }
}
