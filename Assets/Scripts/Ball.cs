using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //config params
    [SerializeField] float randomFactor = 1f;
    [SerializeField] AudioClip[] ballSounds;

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

            if (Input.GetMouseButtonDown(0))
            {
                paddleZ = paddle.GetZValue() * -50f;
                print("Paddle Angle: " + paddleZ);
                hasStarted = true;
                myRigidBody2D.velocity = new Vector2(2f, 0f);
                myRigidBody2D.AddForce(new Vector2(paddleZ, 10f), ForceMode2D.Impulse);
            }
        }
	}

    private void OnCollisionEnter2D()
    {
        Vector2 velocityOffset = new Vector2
            (UnityEngine.Random.Range(0, randomFactor), 
            UnityEngine.Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            myRigidBody2D.velocity += velocityOffset;
        }
    }

}
