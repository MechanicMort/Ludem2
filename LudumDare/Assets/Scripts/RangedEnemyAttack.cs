using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour {

    public GameObject goPlayer;
    private Vector3 playerVector;
    private Vector3 enemyVector;
    private float dist;
    public GameObject goProjectile;
    private bool bAttack;
	// Use this for initialization
	void Start () {
        bAttack = true;

    }
	
	// Update is called once per frame
	void Update () {
        playerVector = goPlayer.transform.position;
        enemyVector = this.transform.position;
        dist = Vector3.Distance(playerVector, enemyVector);
        print(dist);
        if (dist > 2f && bAttack == true)
        {
            StartCoroutine("Attack");
        }
	}
    private IEnumerator Attack()
    {
        bAttack = false;
        yield return new WaitForSeconds(1f);
        Instantiate(goProjectile, new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 0), transform.rotation);
        bAttack = true;
    }
}
