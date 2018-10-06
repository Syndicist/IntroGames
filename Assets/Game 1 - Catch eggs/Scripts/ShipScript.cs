using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour
{
    public Transform explosionPrefab;
    public Transform laserPrefab;
    PlayerSystem myPlayerSystem;
    Rigidbody rb;
    Rigidbody lrb;

    //Automatically run when a scene starts
    void Awake()
    {
        myPlayerSystem = GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (myPlayerSystem.gameOver)
        {
            Destroy(gameObject);
        }
        else
        {
            //Control movement
            Vector3 rotationInput = new Vector3(0, Input.GetAxis("Rotate") * 3, 0);
            float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
            float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * 3;

            Vector3 forwardForceVector = new Vector3(verticalInput * 50, verticalInput * 50, 0);
            Vector3 strafeForceVector = new Vector3(horizontalInput * 5, horizontalInput * 25, 0);
            if (horizontalInput > 0 || horizontalInput < 0)
            {
                rb.drag = 0;
                rb.AddRelativeForce(Vector3.Scale(Vector3.right,strafeForceVector), ForceMode.Acceleration);
            }
            if (verticalInput > 0)
            {
                rb.drag = 0;
                rb.AddForce(Vector3.Scale(transform.forward, forwardForceVector), ForceMode.Acceleration);
            }
            else if (verticalInput < 0)
                rb.drag += .1f;
            transform.Rotate(rotationInput);

            //Fire laser
            bool fire = Input.GetKeyDown(KeyCode.Space);
            if(fire)
            {
                var laser = Instantiate(laserPrefab, transform.position, transform.rotation);
                lrb = laser.GetComponent<Rigidbody>();
                lrb.AddForce(laser.forward * 10, ForceMode.Impulse);
            }

            //Restrict movement between two values
            float xmax = 10;
            float ymax = 4;
            if (transform.position.x <= -xmax || transform.position.x >= xmax)
            {
                float xPos = Mathf.Clamp(transform.position.x, -xmax, xmax); //Clamp between min -2.5 and max 2.5
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            }
            if (transform.position.y <= -ymax || transform.position.y >= ymax)
            {
                float yPos = Mathf.Clamp(transform.position.y, -ymax, ymax); //Clamp between min -2.5 and max 2.5
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            }
        }
    }

    //Triggered by Unity's Physics
    void OnTriggerEnter(Collider other)
    {
        GameObject collisionGO = other.gameObject;
        if (collisionGO.tag == "enemy")
        {
            Destroy(collisionGO);
            myPlayerSystem.hp--;
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
