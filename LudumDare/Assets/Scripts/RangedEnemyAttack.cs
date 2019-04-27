using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour {

    public GameObject goPlayer;
    private Vector3 playerVector;
    private Vector3 enemyVector;
    private float dist;
    public GameObject goProjectile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerVector = goPlayer.transform.position;
        enemyVector = this.transform.position;
        dist = Vector3.Distance(playerVector, enemyVector);
        if (dist < 0.95f)
        {

        }
	}
}
