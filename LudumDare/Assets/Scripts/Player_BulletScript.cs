using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletScript : MonoBehaviour {

    private GameObject goPlayer;
    private Rigidbody2D rgbd;
    public float fSpeed;
    public float fDamage;
    // Use this for initialization
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        rgbd = GetComponent<Rigidbody2D>();
        StartCoroutine("Zoom");
    }


    private IEnumerator Zoom()
    {
        this.transform.Translate(Vector3.up * fSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("Zoom");
        StartCoroutine("Die");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider);
        if ( collider.tag == "Enemy")
        {
            collider.SendMessage("DamageTaken",fDamage);
        }
        if (collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
