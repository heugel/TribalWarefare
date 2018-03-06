using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacker : MonoBehaviour {

    public float knockback = 4;
    public float blockback = 1;
    public float hitstun = .4f;

    public float damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        Rigidbody otherrb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 kbvec = transform.parent.parent.GetChild(0).forward;
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
                otherrb.gameObject.GetComponent<Caveman_RB>().Hitstun(hitstun);

                otherrb.gameObject.GetComponent<Health_Caveman>().Damage(damage);
                if (otherrb.gameObject.GetComponent<Health_Caveman>().GetCurHealth() <= 0)
                {

                }
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
