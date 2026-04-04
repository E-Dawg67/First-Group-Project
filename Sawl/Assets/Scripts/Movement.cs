using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float x, y;
    Vector3 move;
    public GameObject bullet, colided;
    public Transform spawnPoint;
    private Rigidbody rb;
    private bool jump = true, moveable = true;
    int ammo = 7;
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,Input.GetAxis("Mouse X") * 5f,0);
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        move = transform.right * y * -1 + transform.forward * x;
        rb.MovePosition(this.transform.position + (move * 80f * Time.deltaTime));
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jump)
        {
            rb.linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 10f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
        if(Input.GetMouseButtonDown(0) && ammo > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (colided == null)
        {
            jump = true;
            colided = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == colided)
        {
            jump = false;
            colided = null;
        }
    }
}
