using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpTheThing : MonoBehaviour {

    public BaseAttack myAttack;
    public Transform playerPos;
    public float buyDistance;
    public Text NameSpace;
    public Text ItemCost;

    void Start()
    {
        playerPos = PlayerMovement.player.gameObject.transform;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.E)  && (transform.position - playerPos.position).magnitude <= buyDistance) {
            PlayerMovement.player.PickUp(myAttack, gameObject);
            PlayerMovement.player.fHealth -= myAttack.Cost;
        }
        NameSpace.text = myAttack.AttackName;
        ItemCost.text = "Cost: " + myAttack.Cost.ToString();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, buyDistance);
    }
}
