using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float x, y;
    public GameObject bullet;
    public Transform spawnPoint;
    int ammo = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x * 6f * Time.deltaTime, 0, y * 6f * Time.deltaTime);
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            this.gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 10f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
        if(Input.GetMouseButtonDown(0) && ammo > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
