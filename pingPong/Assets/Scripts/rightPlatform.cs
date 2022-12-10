using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPlatform : MonoBehaviour {

    public float speed = 1f;
    public float rotationSpeed = 0.001f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Motion();
        Rotation();
        int dir = 0;
        if (Input.GetKey(KeyCode.UpArrow)) {
            dir = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = -1;
        }
        rb.velocity = new Vector2(rb.velocity.x, dir * speed);
    }
    private void Motion() {
        int dir = 0;
        if (Input.GetKey(KeyCode.UpArrow)) {
            dir = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = -1;
        }
        rb.velocity = new Vector2(rb.velocity.x, dir * speed);
    }
    private void Rotation() {

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (rb.rotation > 45) {
                rb.rotation -= rotationSpeed;
            }
            else {
                rb.rotation = 45;
            }
        }


        else if (Input.GetKey(KeyCode.LeftArrow)) {
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
        //if (Input.GetKey(KeyCode.RightArrow)) {
        //    rb.rotation += -rotationSpeed;
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow)) {
        //    rb.rotation += rotationSpeed;

        //}
    }
};
