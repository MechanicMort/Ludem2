using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject melleEnemy;
    public GameObject rangedEnemy;
    public float level;
    public bool wavesComplete;

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Spawn()
    {
        for (int i = 0; i < 2*level; i++)
        {
            Instantiate(melleEnemy, transform.position, transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(10f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position, transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(20f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position, transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(30f);
        level += 1;
    }
}
