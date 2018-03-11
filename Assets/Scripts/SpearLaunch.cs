using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearLaunch : MonoBehaviour {

    public float force;
    //public Quaternion startangle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Prepare(Quaternion startangle, PlayerInteraction PI)
    {
        transform.rotation = startangle;
        gameObject.SetActive(true);
        GetComponent<Knockbacker>().SetPI(PI);
        Activate();
    }

    public void Activate()
    {
        GetComponent<Rigidbody>().AddForce(transform.up.normalized * force, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            if (GetComponent<Knockbacker>().PI.gameObject == other.gameObject)
            {
                return;
            }
            else //if (other.gameObject.tag == "Player")
            {
                gameObject.SetActive(false); //make sure this calls AFTER knockback
            }

            //make it so you can pick it up here?
        }
    }
}
