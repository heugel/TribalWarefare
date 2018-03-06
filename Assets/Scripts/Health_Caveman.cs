using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Caveman : MonoBehaviour {

    public float MaxHP = 50;
    private float curhp;

    public GameObject healthbar;
    private Vector3 healthscale;

    // Use this for initialization
    void Start ()
    {
        curhp = MaxHP;
        healthscale = healthbar.transform.localScale;
    }

    public float GetCurHealth() { return curhp; }
    public void Damage(float dam)
    {
        curhp -= dam;
        if (curhp < 0)
        {
            curhp = 0;

            //Die();
            //Respawn();
        }

        healthscale.x = curhp / MaxHP;
        healthbar.transform.localScale = healthscale;
    }
}
