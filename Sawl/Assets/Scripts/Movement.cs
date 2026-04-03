using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float x, y;
    Vector3 move;
    public GameObject bullet;
    public Transform spawnPoint;
    int ammo = 7;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,Input.GetAxis("Mouse X") * 5f,0);
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        move = transform.right * y * -1 + transform.forward * x;
        transform.position += move * 25f * Time.deltaTime;
        if (Keyboard.current.spaceKey.wasPressedThisFrame && transform.position.y < .005f)
        {
            this.gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 10f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
        if(Input.GetMouseButtonDown(0) && ammo > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
