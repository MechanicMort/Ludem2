using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
	
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z  - 10);
	}
}
