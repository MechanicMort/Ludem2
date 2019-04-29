using System.Collections;
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
        StartCoroutine("Damage");
    }

    void OnTriggerStay2D(Collider2D collider) 
    {

        if (bAttack == true)
        {
            print("hey");
            collider.SendMessage("DamageDealt",10);
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
        yield return new WaitForSeconds(1f);
        bAttack = true;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("Damage");
    }
}
