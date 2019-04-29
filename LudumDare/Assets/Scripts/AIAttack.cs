﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {

    private bool bAttack;

	// Use this for initialization
	void Start () {
        bAttack = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        print("aye");
        StartCoroutine("Damage");
    }

    void OnTriggerStay2D(Collider2D collider) 
    {

        if (bAttack == true)
        {
            print("hey");
            collider.SendMessage("DamageDealt",10);
            bAttack = false;
            StartCoroutine("Damage");
        }
    }
    void OnTriggerExit2D(Collider2D collider )
    {
        if (collider.tag == "Player")
        {
            StopAllCoroutines();
        }

    }

    private IEnumerator Damage()
    {
        bAttack = false;
        print("1");
        yield return new WaitForSeconds(1f);
        bAttack = true;
        print("2");
    }
}
