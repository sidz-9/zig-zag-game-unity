using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject particle;

    [SerializeField]    // you can use this instead of public to make the field visible in the editor
    private float speed;
    bool started;
    bool gameOver;

    // Called before Start method
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started) {
            if(Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameController.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)) {    // if the raycast is not colliding with any object, then make the ball fall down
            rb.velocity = new Vector3(0, -speed * 2, 0);
            gameOver = true;

            Camera.main.GetComponent<CameraFollow>().gameOver = true;  // make the gameOver field of CameraFollow script, so that camera will stop following the ball.
        
            GameController.instance.StopGame();
        }

        if(Input.GetMouseButtonDown(0) && !gameOver) {
            SwitchDirection();
        }
    }

    void SwitchDirection() {
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    // destroy diamond on ball enter
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Diamond") {
            GameObject particleObject = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(particleObject, 1f);
        }
    }
}
