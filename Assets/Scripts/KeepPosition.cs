using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPosition : MonoBehaviour {
    private Vector3 LocalPosition;
    private Quaternion LocalRot;
	// Use this for initialization
	void Start () {
        LocalPosition = transform.localPosition;
        LocalRot = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = LocalPosition;
        transform.localRotation = LocalRot;
	}
}
