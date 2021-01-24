using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardZ : MonoBehaviour

{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( new Vector3(0,0,1) * Time.deltaTime * speed);
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Flower"))
        {
            Destroy(other.gameObject);
        }
    }
}
