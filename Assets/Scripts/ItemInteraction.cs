using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ItemInteraction : NetworkBehaviour
{
    [ClientRpc]
    public void Rpc_KB(Vector3 kbvec)
    {
        GetComponent<Rigidbody>().AddForce(kbvec, ForceMode.VelocityChange);
    }

}
