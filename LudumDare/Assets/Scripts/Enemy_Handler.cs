using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Handler : MonoBehaviour {

    public float fHealth;
	// Use this for initialization
	void Start () {
        fHealth = 50;
	}
	
	// Update is called once per frame
	void Update () {
        if (fHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void DamageTaken(float fDamage)
    {
        fHealth -= fDamage;
    }
}
