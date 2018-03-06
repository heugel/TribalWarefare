﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
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
    // Use this for initialization
    void Start()
    {
        BodyAnim = Body.GetComponent<Animator>();

        clubblock = transform.GetChild(0).gameObject;

        //clubswing = transform.GetChild(1).gameObject;
        origclubpos = clubswing.transform.localPosition;
        origclubrot = clubswing.transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        BodyAnim.SetBool("hit", Swinging);
    }

    public bool isSwinging()
    {
        return Swinging;
    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(.05f);
        Swinging = true;
        clubswing.GetComponent<CapsuleCollider>().enabled = true;
        yield return new WaitForSeconds(.45f);
        clubswing.GetComponent<CapsuleCollider>().enabled = false;

        clubswing.transform.localPosition = origclubpos;
        clubswing.transform.localRotation = origclubrot;
        Swinging = false;
    }
}