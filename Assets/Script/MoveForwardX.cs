using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed = 5;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        for (; ; )
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 1);
            yield return new WaitForSeconds(5f);
        }
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
