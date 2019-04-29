using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavalScript : MonoBehaviour {

    private bool bAttack;

    // Use this for initialization
    void Start()
    {
        bAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine("Damage");
        collider.SendMessage("DamageDealt", 10);
    }

    void OnTriggerStay2D(Collider2D collider)
    {

        if (bAttack == true)
        {
            collider.SendMessage("DamageDealt", 10);
            bAttack = false;

        }
    }

    private IEnumerator Damage()
    {
        bAttack = false;
        yield return new WaitForSeconds(1f);
        bAttack = true;
        StartCoroutine("Damage");

    }
}
