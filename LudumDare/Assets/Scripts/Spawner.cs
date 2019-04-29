using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject melleEnemy;
    public GameObject rangedEnemy;
    public GameObject healthDrop;
    public float level;
    public bool wavesComplete;
    public static Spawner spawnClass;

	// Use this for initialization
	void Start () {
        if (Spawner.spawnClass == null)
        {
            spawnClass = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
        wavesComplete = false;

    }
	
    void OnLevelWasLoaded()
    {
        print("'mornin");
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine("Spawn");

        }   
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
        print("Entered" + level);
        for (int i = 0; i < 2*level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1,3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(5*level/2f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(5 * level / 2f);
        level += 1;
        for (int i = 0; i < 2 * level; i++)
        {
            Instantiate(melleEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        for (int i = 0; i < 1 * level; i++)
        {
            Instantiate(rangedEnemy, transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)), transform.rotation);
        }
        yield return new WaitForSeconds(5 * level / 2f);
        wavesComplete = true;
        level += 1;
    }
}
