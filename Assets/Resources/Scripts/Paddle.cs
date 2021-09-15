using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config params
    [SerializeField] public float angle = 0f;
    private Vector3 currentRotation;
    private float minAngle;
    private float maxAngle;

    //cached references
    private GameState roboPlay;
    private Ball ballLoc;

    // Use this for initialization
    void Start () {
        roboPlay = FindObjectOfType<GameState>();
        ballLoc = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        currentRotation = this.transform.localEulerAngles;

        float mouseBlocks = GetXPos();

        paddlePos.x = Mathf.Clamp(mouseBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (!roboPlay.EnableAutoplay())
        {
            return (Input.mousePosition.x / Screen.width * 16);
        } else
        {
            return ballLoc.transform.position.x;
        }
    }

    public void RotateLeft()
    {
        minAngle = 30f;
        maxAngle = 30f;
        transform.Rotate(0f, 0f, 0f, Space.Self);
        currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minAngle, maxAngle); // clamp z rotation
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RotateRight()
    {
        minAngle = -30f;
        maxAngle = -30f;
        transform.Rotate(0f, 0f, 0f, Space.Self);
        currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minAngle, maxAngle); // clamp z rotation
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void ReturnMiddle()
    {
        minAngle = 0f;
        maxAngle = 0f;
        transform.Rotate(0f, 0f, 0f, Space.Self);
        currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minAngle, maxAngle); // clamp z rotation
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public float GetZValue()
    {
        return this.transform.rotation.z;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var localDirection = ballLoc.transform.InverseTransformDirection(ballLoc.gameObject.GetComponent<Rigidbody2D>().velocity);
        ballLoc.gameObject.GetComponent<Rigidbody2D>().AddForce(localDirection * 0.01f, ForceMode2D.Impulse);
    }
}
