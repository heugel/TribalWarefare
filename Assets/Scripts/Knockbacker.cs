using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacker : MonoBehaviour {

    public float knockback = 4;
    public float blockback = 1;
    public float hitstun = .4f;

    public float damage = 0;

    public PlayerInteraction PI;

    private void OnTriggerEnter(Collider other)
    {
        
        Rigidbody otherrb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 kbvec = PI.gameObject.transform.GetChild(0).forward;
        kbvec.y = .2f;
        kbvec *= knockback;
        if (otherrb)
        {
            Debug.Log(other.gameObject.name);
            //play sound effect
            //based on tag?

            //add team checker for these parts
            if (otherrb.gameObject.tag == "Player")
            {
                PI.Cmd_Hitstun(otherrb.gameObject, hitstun);
                PI.Cmd_Knockback(otherrb.gameObject, kbvec);
                PI.Cmd_Damage(otherrb.gameObject,damage);
                //Debug.Log("network hit");
                //otherrb.gameObject.GetComponent<HitstunCaller>().Rpc_Hitstun(hitstun);

                //otherrb.gameObject.GetComponent<Health_Caveman>().Damage(damage);
                //Cmd_Caller(otherrb.gameObject, kbvec);
                //if (otherrb.gameObject.GetComponent<Health_Caveman>().GetCurHealth() <= 0)
                //{
                    //+1 kill
                //}
            }
            else if (otherrb.gameObject.tag == "OnlinePlayer")
            {
                otherrb.gameObject.GetComponent<Caveman_RB>().Hitstun(hitstun);
            }
            else if (otherrb.gameObject.tag == "AIPlayer")
            {
                otherrb.gameObject.GetComponent<AI_Caveman>().Hitstun(hitstun);
                
            }
            else
            {
                otherrb.AddForce(kbvec, ForceMode.VelocityChange);
            }
        }
    }
}
