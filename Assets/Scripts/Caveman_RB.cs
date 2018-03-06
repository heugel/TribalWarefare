using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveman_RB : MonoBehaviour
{

    private Rigidbody controller;
    private Vector3 moveVector;
    private Collider body;
    private float distground;
    private Vector3 direction = Vector3.zero;

    public float JumpPower = 10;
    public float MoveSpeed = 5;
    private float OrigSpeed;
    public float TimeScale = 50f;


    public GameObject RotationTracker;

    //private Attack2 AtkMain;

    public GameObject Body;
    private Animator BodyAnim;

    public Color TeamColor;
    
    // Use this for initialization
    void Start()
    {

        controller = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
        distground = body.bounds.extents.y;
        OrigSpeed = MoveSpeed;

        //AtkMain = transform.GetChild(2).GetComponent<Attack2>();
        //AtkMain=transform.FindChild("Hitboxes").GetComponent<Attack2>();
        BodyAnim = Body.GetComponent<Animator>();

    }

    public void TeamSet(Color newcol) { TeamColor = newcol;  }
    public Color TeamGet() { return TeamColor; }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distground + 0.04f);
    }

    // Update is called once per frame
    void Update()
    {

        BodyAnim.SetBool("walk", direction!=Vector3.zero);

        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y-(distground+.07f), transform.position.z), Color.red);

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Damage(5);
                controller.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.LeftShift))
                MoveSpeed = OrigSpeed / 5;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
            MoveSpeed = OrigSpeed;

        float gofor = Input.GetAxis("Vertical");
        float goside = Input.GetAxis("Horizontal");

        if (hitstun)
        {
            gofor = 0;
            goside = 0;
        }

        if (gofor != 0 || goside != 0)
        {
            direction = RotationTracker.transform.forward*gofor;
            direction += RotationTracker.transform.right * goside;
            direction.y = 0;
            direction.Normalize();
        }
        /*else if (gofor == 0 && goside == 0 && Mathf.Abs(controller.velocity.x)+Mathf.Abs(controller.velocity.z)>0)
        {
            direction = Vector3.zero;
            controller.velocity *= .3f;
            //Debug.Log("jump blocked");
        }*/
        else if (gofor==0 && goside ==0)
        {
            direction = Vector3.zero;

        }
        else direction = Vector3.zero;
        
    }

    private void FixedUpdate()
    {
        //Debug.Log(IsGrounded());
        if (IsGrounded())
        {
            controller.AddForce(direction * MoveSpeed * Time.deltaTime * TimeScale, ForceMode.VelocityChange);
            if (controller.velocity.magnitude > MoveSpeed)
            {
                controller.velocity = controller.velocity.normalized * MoveSpeed;
            }

            if(direction==Vector3.zero)// && (controller.velocity.x!=0 || controller.velocity.z != 0))
            {
                controller.velocity = new Vector3(controller.velocity.x * .3f, controller.velocity.y, controller.velocity.z * .3f);
            }
        }
        else
        {
            controller.AddForce(direction * 3f * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Debug.Log(controller.velocity.magnitude);
    }

    private bool hitstun = false;
    public void Hitstun(float t)
    {
        hitstun = true;
        StartCoroutine("HitstunTimer", t);
    }
    IEnumerator HitstunTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        hitstun = false;
    }





}
