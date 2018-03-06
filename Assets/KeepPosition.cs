using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPosition : MonoBehaviour {
    private Vector3 LocalPosition;
	// Use this for initialization
	void Start () {
        LocalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = LocalPosition;
	}
}
