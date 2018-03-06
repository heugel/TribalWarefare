using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Knockbacker : NetworkBehaviour {

    public float knockback = 4;
    public float blockback = 1;
    public float hitstun = .4f;

    public float damage = 0;

    [Command]
    void Cmd_Caller(GameObject go, Vector3 kbvec)
    {
        go.GetComponent<HitstunCaller>().Rpc_Hitstun(hitstun, kbvec);

    }


    private void OnTriggerEnter(Collider other)
    {
        
        Rigidbody otherrb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 kbvec = transform.GetChild(0).forward;
        kbvec.y = .2f;
        kbvec *= knockback;
        if (otherrb)
        {
            Debug.Log(other.gameObject.name);
            //play sound effect
            //based on tag?

            otherrb.AddForce(kbvec, ForceMode.VelocityChange);
            //add team checker for these parts
            if (otherrb.gameObject.tag == "Player")
            {
                //Debug.Log("network hit");
                //otherrb.gameObject.GetComponent<HitstunCaller>().Rpc_Hitstun(hitstun);

                //otherrb.gameObject.GetComponent<Health_Caveman>().Damage(damage);
                Cmd_Caller(otherrb.gameObject, kbvec);
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
        }
    }
}
