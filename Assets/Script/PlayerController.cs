using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
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
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * forwardSpeed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotateSpeed);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce * forwardSpeed, ForceMode.Impulse);
            isGround = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
