using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTp : MonoBehaviour {

    public Transform Tp;
    public GameObject player;
	// Use this for initialization
	void Start () {
        Tp = transform; 
        player = GameObject.FindWithTag("Player");
        player.SendMessage("TP", Tp);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
