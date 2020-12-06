using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            transform.position += movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);
            transform.position += movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(-1.0f, 0.0f, 0.0f);
            transform.position += movement * Time.deltaTime * speed;
        }
    }
}
