using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config params
    [SerializeField] public float angle = 0f;
    private Vector3 currentAngle;

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
        currentAngle = this.transform.localEulerAngles;

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
        transform.Rotate(Vector3.forward, 0.5f, Space.Self);
    }

    public void RotateRight()
    {
        transform.Rotate(Vector3.forward, -0.5f, Space.Self);
    }

    public float GetZValue()
    {
        return this.transform.rotation.z;
    }

}
