using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float x, y, prevUP;
    Vector3 move;
    public GameObject bullet, colided;
    public Transform spawnPoint;
    private Rigidbody rb;
    public TMP_Text ammoT;
    private bool jump = true;
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jump)
        {
            rb.linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 15f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
        if(Input.GetMouseButtonDown(0) && ammo > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            ammo--;
            ammoT.text = "Ammo: " + ammo;
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ammo = 0;
            ammoT.text = "Reloading...";
            Invoke("reload", 3f);
        }

    }
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        move = transform.right * y * -1 + transform.forward * x;
        prevUP = rb.linearVelocity.y;
        rb.linearVelocity = move * 1000f * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, prevUP, rb.linearVelocity.z);
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
    private void reload()
    {
        ammo = 7;
        ammoT.text = "Ammo: " + ammo;
    }
}
