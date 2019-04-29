using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletScript : MonoBehaviour {

    private GameObject goPlayer;
    public float fSpeed;
    public float fDamage;
    public float ProjectileSpeed;
    public float LifeSpan;
    // Use this for initialization
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("Zoom");
    }


    private IEnumerator Zoom()
    {
        this.transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);
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
            Destroy(this.gameObject);
        }
        if (collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(LifeSpan);
        Destroy(this.gameObject);
    }
}
