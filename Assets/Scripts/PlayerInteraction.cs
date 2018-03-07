using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerInteraction : NetworkBehaviour {


    [ClientRpc]
    public void Rpc_Hitstun(float time)
    {
        if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
        {
            GetComponent<Caveman_RB>().Hitstun(time);
        }
    }

    [ClientRpc]
    public void Rpc_Knockback(Vector3 kbvec)
    {
        if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
        {
            GetComponent<Rigidbody>().AddForce(kbvec, ForceMode.VelocityChange);
        }
    }

    [ClientRpc]
    public void Rpc_Damage(float dam)
    {
        if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
        {
            GetComponent<Health_Caveman>().Damage(dam);
        }
    }

    [Command]
    public void Cmd_Hitstun(GameObject go, float time)
    {
      //  if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
      //  {
            go.GetComponent<PlayerInteraction>().Rpc_Hitstun(time);
      //  }
    }

    [Command]
    public void Cmd_Knockback(GameObject go, Vector3 kbvec)
    {
       // if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
       // {
            go.GetComponent<PlayerInteraction>().Rpc_Knockback(kbvec);
       // }
    }

    [Command]
    public void Cmd_Damage(GameObject go, float dam)
    {
        //if (GetComponent<Caveman_RB>().enabled && isLocalPlayer)
        //{
            go.GetComponent<PlayerInteraction>().Rpc_Damage(dam);
        //}
    }

}
