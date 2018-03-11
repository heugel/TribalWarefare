using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    private GameObject[] spears;

	// Use this for initialization
	void Start ()
    {
        SpearUpdate();
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}

    private void SpearUpdate()
    {
        spears = new GameObject[transform.childCount];
        for(int i = 0; i < spears.Length; i++)
        {
            spears[i] = transform.GetChild(i).gameObject;
        }
    }

    public GameObject Pool()
    {
        for (int i = 0; i < spears.Length; i++)
        {
            if (!spears[i].activeSelf)
            {
                return spears[i];
            }
        }

        GameObject newspear = Instantiate(Resources.Load("SpearWep", typeof(GameObject))) as GameObject;
        newspear.transform.parent = transform;
        SpearUpdate();
        return newspear;

    }
}
