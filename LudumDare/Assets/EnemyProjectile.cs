using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    private GameObject goPlayer;
    private Rigidbody2D rgbd;
	// Use this for initialization
	void Start () {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        rgbd = GetComponent<Rigidbody2D>();
        StartCoroutine("Zoom");
    }


    private IEnumerator Zoom()
    {
        rgbd.AddForce(new Vector3(goPlayer.transform.position.x, goPlayer.transform.position.y, 0));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine("Zoom");
    }
}
