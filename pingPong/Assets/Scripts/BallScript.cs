using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private new Transform transform;
    public float speed = 1f;
    private GameObject leftPlatform;
    private GameObject rightPlatform;
    private bool gameStart = true;
    private Vector3 prevLeftPos, prevRightPos;
    private float prevRot;
    public Quaternion prevLeftRot, prevRightRot;
    private Rigidbody2D rbLeft, rbRight;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        leftPlatform = GameObject.FindGameObjectWithTag("leftPlatform");
        rightPlatform = GameObject.FindGameObjectWithTag("rightPlatform");
        rbLeft = leftPlatform.GetComponent<Rigidbody2D>();
        rbRight = rightPlatform.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        prevLeftPos = leftPlatform.transform.position;
        prevRightPos = rightPlatform.transform.position;
        prevLeftRot = leftPlatform.transform.rotation;
        prevRightRot = rightPlatform.transform.rotation;
        prevRot = rb.rotation;
       // prevRot = rb.transform.rotation;
        rb.position = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate() {
        if (gameStart) {
            if (Input.anyKey) {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                gameStart = false;
            }
        }
        if (GameOver()) {
            RestartRound();
        }
        
    }
    private bool GameOver() {
        //bool gameOver = false;
        if (transform.position.x < leftPlatform.transform.position.x - 5) {

            return true;
        }
        if (transform.position.x > rightPlatform.transform.position.x + 5) {
            
            return true;
        }
        return false;
    }
    private void RestartRound() {
         
        transform.position = new Vector3(0, 0, 0);

        leftPlatform.transform.position = prevLeftPos;        
        rightPlatform.transform.position = prevRightPos;
        leftPlatform.transform.rotation = prevLeftRot;
        rightPlatform.transform.rotation = prevRightRot;
        rb.angularVelocity = 0; //Остановка вращения объекта
        //rb.transform.rotation = prevRot;


        rb.velocity = new Vector2(0, 0);

        gameStart = true;
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "leftPlatform") {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (collision.gameObject.tag == "rightPlatform") {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (collision.gameObject.tag == "topBorder") {
            if (rb.velocity.x < 0) {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
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
