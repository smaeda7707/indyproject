using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float acceleration;
    public float speed;
    [Range(0f,1f)]
    public float drag;

    public Rigidbody2D body;

    private float inpX;
    private float inpY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate(){
        ApplyFriction();
        Movement();
        SetCameraPosition();
    }

    void GetInput(){
        inpX = Input.GetAxis("Horizontal");
        inpY = Input.GetAxis("Vertical");
    }


    void ApplyFriction(){
            body.velocity *= drag;
    }

    void Movement(){
        if (Mathf.Abs(inpX) > 0 || Mathf.Abs(inpY) > 0){
            Vector2 increment = new Vector2(inpX * acceleration, inpY * acceleration);
            body.velocity = new Vector3(Mathf.Clamp(body.velocity.x + increment.x, -speed, speed), Mathf.Clamp(body.velocity.y + increment.y, -speed, speed)); // Last 2 perameters of clamp are limits to the first perameter
        }
    }
    void SetCameraPosition(){
        Camera.main.transform.position = new Vector3(body.position.x, body.position.y, -10);
    }
}
