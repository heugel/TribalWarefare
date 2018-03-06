using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacker : MonoBehaviour {

    public float knockback = 4;
    public float blockback = 1;
    public float hitstun = .4f;

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
            if (otherrb.gameObject.tag == "Player")
            {
                otherrb.gameObject.GetComponent<Caveman_RB>().Hitstun(hitstun);
            }
        }
    }
}
