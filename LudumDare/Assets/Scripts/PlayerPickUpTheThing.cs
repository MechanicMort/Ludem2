using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpTheThing : MonoBehaviour {

    public BaseAttack myAttack;
    public Transform playerPos;
    public float buyDistance;

    void Start()
    {
        playerPos = PlayerMovement.player.gameObject.transform;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.E)  && (transform.position - playerPos.position).magnitude <= buyDistance) {
            PlayerMovement.player.PickUp(myAttack, gameObject);
            PlayerMovement.player.fHealth -= myAttack.Cost;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, buyDistance);
    }
}
