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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * forwardSpeed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotateSpeed);

        if (verticalInput == 0)
        {
            anim.SetFloat("Speed_f", 0.0f);
        }

        else
        {
            anim.SetFloat("Speed_f", 3.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce * forwardSpeed, ForceMode.Impulse);
            isGround = false;
            anim.SetTrigger("Jump_trig");
            //anim.SetBool("Jump_b", true);
        }
        //anim.SetBool("Jump_b", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            Destroy(other.gameObject);
        }
    }
}
