using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private GameObject clubswing, clubend, clubmiddle, clubblock, spearthrow, spearstab;

    private Vector3 origclubpos;
    private Quaternion origclubrot;
    private Vector3 endclubpos;
    private Quaternion endclubrot;
    private Vector3 midclubpos;
    private Quaternion midclubrot;

    private bool Swinging = false;

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
	// Use this for initialization
	void Start ()
    {
        clubblock = transform.GetChild(0).gameObject;

        clubswing = transform.GetChild(1).gameObject;
        origclubpos = clubswing.transform.localPosition;
        origclubrot = clubswing.transform.localRotation;

        clubend = transform.GetChild(2).gameObject;
        endclubpos = clubend.transform.localPosition;
        endclubrot = clubend.transform.localRotation;

        clubmiddle = transform.GetChild(3).gameObject;
        midclubpos = clubmiddle.transform.localPosition;
        midclubrot = clubmiddle.transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isSwinging()
    {
        return Swinging;
    }
    IEnumerator Swing()
    {
        Swinging = true;
        int x = 0;

        clubswing.GetComponent<CapsuleCollider>().enabled = true;
        while (x < 6)
        {
            clubswing.transform.localPosition = Vector3.Lerp(clubswing.transform.localPosition, midclubpos, .25f);
            clubswing.transform.localRotation = Quaternion.Lerp(clubswing.transform.localRotation, midclubrot, .2f);


            yield return new WaitForSeconds(.01f);

            x++;
        }
        x = 0;
        clubswing.GetComponent<CapsuleCollider>().enabled = false;
        while (x < 15)
        {
            clubswing.transform.localPosition = Vector3.Lerp(clubswing.transform.localPosition, endclubpos, .15f);
            clubswing.transform.localRotation = Quaternion.Lerp(clubswing.transform.localRotation, endclubrot, .1f);


            yield return new WaitForSeconds(.01f);

            x++;
        }

        clubswing.transform.localPosition = origclubpos;
        clubswing.transform.localRotation = origclubrot;
        Swinging = false;
    }
}
