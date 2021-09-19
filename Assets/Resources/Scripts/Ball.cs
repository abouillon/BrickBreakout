/**
 * TO-DO: Fix Launch Angles
 * 
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //config params
    [SerializeField] float randomFactor = 1f;
    [SerializeField] AudioClip[] ballSounds;
    private float maxSpeed = 10f;
    private float minSpeed = 8f;

    //state variables
    public bool hasStarted = false;
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
                paddleZ = paddle.GetZValue() * 20f;
                hasStarted = true;
                myRigidBody2D.velocity = new Vector2(paddleZ, 10f);
            }
        }

        if (hasStarted)
        {
            myRigidBody2D.velocity = maxSpeed * (myRigidBody2D.velocity.normalized);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var inertia = 0.5f;
        var maxDeg = 10f;
        var minDeg = -10f;
        Vector2 velocityOffset = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip, 0.45f);
            myRigidBody2D.velocity += velocityOffset;
            var impulse = (UnityEngine.Random.Range(minDeg, maxDeg) * Mathf.Deg2Rad) * inertia;
            myRigidBody2D.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }

}
