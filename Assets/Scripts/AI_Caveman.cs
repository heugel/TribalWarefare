using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Caveman : MonoBehaviour
{

  public List<GameObject> followPath = new List<GameObject>();

  private Rigidbody controller;

  /*
  public float DetRange = 25;
  public float atkrange = 3;

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
  */
  public enum Strategy
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
  public Strategy strategy;


  // Use this for initialization
  void Start() {
    controller = GetComponent<Rigidbody>();
    
    FollowPathOpts.nextPoint = ClosestPoint();

    /*
    curhp = MaxHP;
    body = GetComponent<Collider>();
    distground = body.bounds.extents.y;
    OrigSpeed = MoveSpeed;
    */
  }

  void FixedUpdate() {

    switch(strategy) {
      case Strategy.attack:
        Attack();
        break;
      case Strategy.sneakup:
        SneakUp();
        break;
      case Strategy.firestarter:
        FireStarter();
        break;
      case Strategy.blocking:
        Blocking();
        break;
      case Strategy.followpath:
        FollowPath();
        break;
      case Strategy.hunt:
        Hunt();
        break;
      case Strategy.onguard:
        OnGuard();
        break;
      case Strategy.wander:
      default:
        Wander();
        break;  
    }
    
  }

  private static class AttackOpts {
  
  }


  void Attack() {

  }

  private static class SneakUpOpts {

  }

  void SneakUp() {

  }

  private static class FireStarterOpts {

  }

  void FireStarter() {

  }

  private static class BlockingOpts {

  }

  void Blocking() {

  }

  private static class FollowPathOpts {
    public static int nextPoint = 0;
    public static float lastPush = 0f;
    public static float lastUpdate = 0f;
  }

  void FollowPath() {
    if(FollowPathClosestPoint() != FollowPathOpts.nextPoint) {
      FollowPathOpts.nextPoint = FollowPathClosestPoint();
      Vector3 toNextPath = Vector3.MoveTowards(transform.position, followPath[FollowPathOpts.nextPoint].transform.position, 1f).normalized;
    } else if(Time.time - FollowPathOpts.lastPush > 3f) {

    } else if(Time.time - FollowPathOpts.lastUpdate > 3f) {

    }
    //Random.rotation
  }

  private int FollowPathClosestPoint() {
    int closestPt = 0;
    float minDist = Mathf.Infinity;

    for(int i = 0; i < followPath.Count; i++) {
      float dist = Vector3.Distance(followPath[i].transform.position, transform.position);
      if(dist < minDist) {
        closestPt = i;
        minDist = dist;
      }
    }
    
    return closestPt;
  }

  private static class HuntOpts {

  }

  void Hunt() {

  }

  private static class OnGuardOpts {

  }


  void OnGuard() {

  }

  private static class WanderOpts {
    public static Vector3 direction = Vector3.forward;
    public static float mag = 50f;
    public static float lastUpdate = 0f;
    public static float lastPush = 0f;
  }

  void Wander() {

    if(Time.time - WanderOpts.lastUpdate > Random.Range(3f, 4f)) {
      WanderOpts.lastUpdate = Time.time;
      Vector2 newDir = (Random.insideUnitCircle).normalized;
      WanderOpts.direction = new Vector3(newDir.x, 0, newDir.y);
    }

    if(Time.time - WanderOpts.lastPush > Random.Range(0.25f, 0.5f)) {
      WanderOpts.lastPush = Time.time;
      controller.AddForce(WanderOpts.direction * WanderOpts.mag);
    }
  }

/*
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
*/
/* 
  

  public void TeamSet(Color newcol) { TeamColor = newcol; }
  public Color TeamGet() { return TeamColor; }

  private bool IsGrounded()
  {
      return Physics.Raycast(transform.position, -Vector3.up, distground + 0.04f);
  }

  // Update is called once per frame

  /*
      //ATTACK
      if (Input.GetKeyDown(KeyCode.Mouse0) && !AtkMain.isSwinging())
      {
          AtkMain.LaunchAttack(Attack2.AtkType.swing);
      }
*/

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
      }

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
      }
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
  */

}
