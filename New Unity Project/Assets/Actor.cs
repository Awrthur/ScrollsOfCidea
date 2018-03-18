using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public int health;
    public int damage;
    public float speed = 3f;
    public float jumpForce = 2;
    private bool isGrounded;
    Rigidbody rb;
    public Vector3 jump;

    private void Start()
    {
        damage = 10;
        health = 100;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 0.5f, 0.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            //transform.position += Vector3.up * speed * Time.deltaTime * jumpHeight;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += Vector3.down * speed * Time.deltaTime;
        //}
    }
}
