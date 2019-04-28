using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

    public Vector3[] itemsSpawnSpots;
    public float GizmosSize;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        for (int i = 0; i < itemsSpawnSpots.Length; i++)
        {
            Gizmos.DrawSphere(itemsSpawnSpots[i], GizmosSize);
        }
        
    }
}
