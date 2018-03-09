using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Attack2 : NetworkBehaviour
{
    

    private GameObject clubblock, spearthrow, spearstab;

    public GameObject clubswing;

    private Vector3 origclubpos;
    private Quaternion origclubrot;

    private bool Swinging = false;
    public GameObject Body;
    private Animator BodyAnim;
    public enum AtkType
    {
        swing,
        block,
        spthrow,
        spstab
    }

    public void LaunchAttack(AtkType thetype)
    {
        switch (thetype)
        {
            case AtkType.swing:
                StartCoroutine("Swing");
                break;
            case AtkType.block:
                break;
            case AtkType.spthrow:
                break;
            case AtkType.spstab:
                break;
            default:
                break;
        }
    }
    [Command]
    public void Cmd_SendAnim(bool anim)
    {
        GetComponent<PlayerInteraction>().Rpc_RecAnim("hit",anim);
    }
    // Use this for initialization

    void Start()
    {

        BodyAnim = Body.GetComponent<Animator>();
        
        clubblock = transform.GetChild(0).gameObject;

        //clubswing = transform.GetChild(1).gameObject;
        origclubpos = clubswing.transform.localPosition;
        origclubrot = clubswing.transform.localRotation;

        //Body.GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);

    }

    // Update is called once per frame
    void Update()
    {
        BodyAnim.SetBool("hit", Swinging);
        Cmd_SendAnim(Swinging);
        //Body.GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        //Body.GetComponent<NetworkAnimator>().SetParameterAutoSend(1, true);
        /*if (isLocalPlayer)
        {
            GetComponent<NetworkAnimator>().GetParameterAutoSend(0);
            GetComponent<NetworkAnimator>().GetParameterAutoSend(1);
        }

        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        GetComponent<NetworkAnimator>().SetParameterAutoSend(1, true);*/
    }

    public bool isSwinging()
    {
        return Swinging;
    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(.2f);
        Swinging = true;
        clubswing.GetComponent<CapsuleCollider>().enabled = true;
        yield return new WaitForSeconds(.3f);
        clubswing.GetComponent<CapsuleCollider>().enabled = false;

        clubswing.transform.localPosition = origclubpos;
        clubswing.transform.localRotation = origclubrot;
        Swinging = false;
    }
}
