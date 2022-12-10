using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPlatform : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 0.001f;
    private Rigidbody2D rb;
    private Quaternion prevRot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        prevRot = rb.transform.rotation;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* float vert = Input.GetAxis("Vertical");
         Vector3 tempVect = new Vector3(0, vert, 0);
         tempVect = tempVect.normalized * speed * Time.deltaTime;
         rb.MovePosition(rb.transform.position + tempVect);
        */


        //int dir = ? 1 : -1;
        Motion();
        Rotation();

    }
    private void Motion() {
        int dir = 0;
        if (Input.GetKey(KeyCode.W)) {
            dir = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            dir = -1;
        }
        rb.velocity = new Vector2(rb.velocity.x, dir * speed);
    }
    private void Rotation() {
        
        if (Input.GetKey(KeyCode.D)) {
            if (rb.rotation > 45) {
                rb.rotation -= rotationSpeed;
            }
            else {
                rb.rotation = 45;
            }
        }
        

        else if (Input.GetKey(KeyCode.A)) {
            if (rb.rotation < 135) {
                rb.rotation += rotationSpeed;
            }
            else {
                rb.rotation = 135;
            }
        }
        else {
            rb.rotation = 90;
        }
       
            //rb.rotation = 90;
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "topBorder") {
            rb.velocity = new Vector2(0, -speed);
        }
        if (collision.gameObject.tag == "botBorder") {
            if (rb.velocity.x < 0) {
                rb.velocity = new Vector2(-speed, speed);
            }
            else {
                rb.velocity = new Vector2(speed, speed);
            }
        }
    }

}
