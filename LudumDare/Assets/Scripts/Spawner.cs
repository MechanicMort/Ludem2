using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject melleEnemy;
    public GameObject rangedEnemy;
    public GameObject healthDrop;
    public float level;
    public bool wavesComplete;

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
        wavesComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (wavesComplete == true)
        {
            Instantiate(healthDrop, transform.position, transform.rotation);
            wavesComplete = false;
        }
	}

    private IEnumerator Spawn()
    {
        for (int i = 0; i < 2*level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1,3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(10f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(15f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(20f);
        wavesComplete = true;
        level += 1;
    }
}
