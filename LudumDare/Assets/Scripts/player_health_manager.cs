using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_health_manager : MonoBehaviour {

    public float fHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fHealth <= 0)
        {
            SceneManager.LoadScene(0);
            print("Dead");
        }
	}

    private void DamageGiven(float fDamage)
    {
        print(fHealth);
        fHealth -= fDamage;
    }
}
