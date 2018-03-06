using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitstunCaller : NetworkBehaviour {

    [ClientRpc]
    public void Rpc_Hitstun(float time, Vector3 kbvec)
    {
        if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
        {
            Debug.Log("network hit");
            GetComponent<Rigidbody>().AddForce(kbvec, ForceMode.VelocityChange);
            GetComponent<Caveman_RB>().Hitstun(time);
        }
    }

}
