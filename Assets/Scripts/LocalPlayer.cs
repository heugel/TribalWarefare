﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class LocalPlayer : NetworkBehaviour
{

    //[SerializeField]
    //GameObject buttons, menus;

    public GameObject playercam;

    public MeshRenderer beard, hair;
    public SkinnedMeshRenderer body, bag;
    public GameObject playerui;


    private bool doneyet = false;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            playercam.GetComponent<Camera>().enabled = true;
            GetComponent<Caveman_RB>().enabled = true;
            GetComponent<SmoothMouseLook>().enabled = true;
            GetComponent<Attack_Caveman>().enabled = true;

            GameObject.Find("WaitingCamera").SetActive(false);

            doneyet = true;
        }
        else
        {
            beard.enabled = true;
            hair.enabled = true;
            body.enabled = true;
            bag.enabled = true;
            playerui.SetActive(false);

            //GetComponent<Caveman_RB>().enabled = true;

            playercam.GetComponent<Camera>().enabled = false;
            playercam.GetComponent<AudioListener>().enabled = false;
            playercam.GetComponent<SmoothMouseLook>().enabled = false;

            //GameObject.Find("WaitingCamera").SetActive(false);

            doneyet = true;
        }
    }
    private void Update()
    {
        if (doneyet)
        {
            //GetComponent<LocalPlayer>().enabled = false;
        }
    }


}