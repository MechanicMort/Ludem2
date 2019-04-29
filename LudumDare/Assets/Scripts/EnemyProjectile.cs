using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    private GameObject goPlayer;
    private Rigidbody2D rgbd;
    public float fSpeed;
	// Use this for initialization
	void Start () {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        rgbd = GetComponent<Rigidbody2D>();
        StartCoroutine("Zoom");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.SendMessage("DamageDealt", 10);
        }
    }

    private IEnumerator Zoom()
    {
        this.transform.Translate(Vector3.up * fSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("Zoom");
        StartCoroutine("Die");
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
