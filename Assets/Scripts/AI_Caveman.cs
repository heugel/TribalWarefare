using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Caveman : MonoBehaviour
{
    public float DetRange = 25;
    public float atkrange = 3;

    private Rigidbody controller;
    private Vector3 moveVector;
    private Collider body;
    private float distground;
    private Vector3 direction = Vector3.zero;

    public float JumpPower = 10;
    public float MoveSpeed = 5;
    private float OrigSpeed;
    public float TimeScale = 50f;

    public float MaxHP = 50;
    private float curhp;

    //public GameObject RotationTracker;

    private Attack2 AtkMain;

    public GameObject Body;
    private Animator BodyAnim;

    public Color TeamColor;

    public enum Strat
    {
        wander,
        attack,
        sneakup,
        onguard,
        blocking,
        hunt,
        firestarter,
        follow,
        followpath
    }
    private Strat strat = Strat.wander;

    // Use this for initialization
    void Start()
    {
        curhp = MaxHP;

        controller = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
        distground = body.bounds.extents.y;
        OrigSpeed = MoveSpeed;

        //change this
        AtkMain = transform.GetChild(2).GetComponent<Attack2>();

        BodyAnim = Body.GetComponent<Animator>();
    }

    IEnumerator Wander()
    {
        while (strat == Strat.wander)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 20f);
            direction = transform.forward;
            direction.y = 0;
            direction.Normalize();
            yield return new WaitForEndOfFrame();
        }
        
    }

    void Attack()
    {

    }

    public void TeamSet(Color newcol) { TeamColor = newcol; }
    public Color TeamGet() { return TeamColor; }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distground + 0.04f);
    }

    // Update is called once per frame
    void Update()
    {
        //ATTACK
        if (Input.GetKeyDown(KeyCode.Mouse0) && !AtkMain.isSwinging())
        {
            AtkMain.LaunchAttack(Attack2.AtkType.swing);
        }


        //MOVEMENT
        //bool tempground = IsGrounded();
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y-(distground+.07f), transform.position.z), Color.red);

        /*if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.LeftShift))
                MoveSpeed = OrigSpeed / 5;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                MoveSpeed = OrigSpeed;
        }*/

        float gofor = Input.GetAxis("Vertical");
        float goside = Input.GetAxis("Horizontal");

        if (hitstun)
        {
            gofor = 0;
            goside = 0;
        }

        /*if (gofor != 0 || goside != 0)
        {
            direction = RotationTracker.transform.forward * gofor;
            direction += RotationTracker.transform.right * goside;
            direction.y = 0;
            direction.Normalize();
        }*/
        /*else if (gofor == 0 && goside == 0 && Mathf.Abs(controller.velocity.x)+Mathf.Abs(controller.velocity.z)>0)
        {
            direction = Vector3.zero;
            controller.velocity *= .3f;
            //Debug.Log("jump blocked");
        }*/
        else if (gofor == 0 && goside == 0)
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

            if (direction == Vector3.zero)// && (controller.velocity.x!=0 || controller.velocity.z != 0))
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
