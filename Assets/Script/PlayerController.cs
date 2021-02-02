using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator anim;
    public float rotateSpeed = 30;
    public float forwardSpeed = 10;
    public float jumpForce = 20;
    public float horizontalInput;
    public float verticalInput;
    private bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = 100;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        if (verticalInput == 0)
        {
            anim.SetFloat("Speed_f", 0.0f);
        }

        else
        {
            anim.SetFloat("Speed_f", 3.0f);
        }

        anim.SetBool("Crouch_b", false);


        // Jump command
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce * forwardSpeed, ForceMode.Impulse);
            isGround = false;
            anim.SetTrigger("Jump_trig");
        }

        // Pick up Command
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject closestObject = gameObject;
            bool flowerIsClose = false;

            // Find nearest flower tag in radius of player and destroy flower object
            anim.SetBool("Crouch_b", true);
            // Find colliders near my
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 3f);
            foreach (Collider flower in colliders) {
                if (flower.gameObject.tag == "Flower")
                {
                    float currentDistance = Vector3.Distance(gameObject.transform.position, flower.gameObject.transform.position);
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        closestObject = flower.gameObject;
                        flowerIsClose = true;
                    }
                }
            }

            if (flowerIsClose)
            {
                Destroy(closestObject);
            }
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch_Down") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch_Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch_Up"))
        {
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * forwardSpeed);
            transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotateSpeed);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Flower"))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
