using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //config params
    [SerializeField] float randomFactor = 2f;
    [SerializeField] AudioClip[] ballSounds;
    private float speed = 10f;

    //state variables
    private bool hasStarted = false;
    private float paddleZ;

    //cached references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    
    // Use this for initialization
    void Start () {
        paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        //paddleZ = paddle.transform.rotation.z;

    }
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            paddleZ = paddle.GetZValue() * -50f;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 ballVector = new Vector2(2f, 10f);
                //paddleZ = paddle.GetZValue() * -50f;
                //print("Paddle Angle: " + paddleZ);
                hasStarted = true;
                //myRigidBody2D.angularVelocity = paddleZ;
                myRigidBody2D.velocity = ballVector.normalized * speed;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Hit " + collision.gameObject.name);

        Vector2 velocityOffset = new Vector2(UnityEngine.Random.Range(2f, randomFactor),
            UnityEngine.Random.Range(2f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            //print(myRigidBody2D.velocity);
            myRigidBody2D.velocity += velocityOffset.normalized;
        }
    }

}
