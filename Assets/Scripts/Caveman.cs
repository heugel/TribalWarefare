using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveman : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;

    public float JumpPower = 10;
    public float FallSpeed = 14;
    public float MoveSpeed = 5;
    public float AirSpeed = 7;

    public GameObject RotationTracker;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion newrot = RotationTracker.transform.rotation;
        newrot.x = 0;
        newrot.z = 0;
        transform.rotation = newrot;

        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = JumpPower;
                Debug.Log(transform.forward);
            }
        }
        else
        {
            verticalVelocity -= FallSpeed * Time.deltaTime;
        }

        

        moveVector = Vector3.zero;
        moveVector = transform.forward * Input.GetAxis("Vertical");// * MoveSpeed;
        moveVector += transform.right * Input.GetAxis("Horizontal");
        moveVector.Normalize();
        if (controller.isGrounded)
            moveVector *= MoveSpeed;
        else moveVector *= AirSpeed;
        //moveVector.x = transform.forward.x * Input.GetAxis("Horizontal") * MoveSpeed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
	}
}
