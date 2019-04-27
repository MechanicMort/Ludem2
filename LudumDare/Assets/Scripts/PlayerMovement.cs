﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float xMove;
    private float yMove;
    public float speed;


    public bool isFiring;
    public Camera mainCam;
    public Rigidbody2D rb;

    public BaseAttack[] myAttacks = new BaseAttack[4];

    public Image[] frames =  new Image[4];
    public GameObject[] Selector = new GameObject[4];

    public int myCurrentObject;
    public static PlayerMovement player;
 

    void Wake ()
    {
        player = this;
    }

    void Start()
    {
        myCurrentObject = 0;
        isFiring = true;
        mainCam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();
        SetFrames();

    }

    void SetFrames()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            print(i);
            if (myAttacks[i] != null)
            {
                frames[i].sprite = myAttacks[i].UIElement;
            }
            Selector[i].SetActive(false);
            Selector[myCurrentObject].SetActive(true);

        }
        

    }
    
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        
        Vector2 MovementDirection = new Vector2(xMove, yMove);

        rb.velocity = MovementDirection * speed * Time.deltaTime;

        rotateAround();
        changeSelected();

    }

    void changeSelected ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && myAttacks[0] != null)
        {
            Selector[myCurrentObject].SetActive(false);
            myCurrentObject = 0;
            Selector[myCurrentObject].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && myAttacks[1] != null)
        {
            Selector[myCurrentObject].SetActive(false);
            myCurrentObject = 1;
            Selector[myCurrentObject].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && myAttacks[2] != null)
        {
            Selector[myCurrentObject].SetActive(false);
            myCurrentObject = 2;
            Selector[myCurrentObject].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && myAttacks[3] != null)
        {
            Selector[myCurrentObject].SetActive(false);
            myCurrentObject = 3;
            Selector[myCurrentObject].SetActive(true);
        }
    }

    void rotateAround()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

        IEnumerator waitFire()
    {

        //FireMissiles();
        isFiring = false;
        yield return new WaitForSeconds(1.5f);
        isFiring = true;
    }

}