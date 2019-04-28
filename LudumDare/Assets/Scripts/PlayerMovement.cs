using System.Collections;
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

    public Image healthBar;
    public float fHealth;









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
        fHealth = 100f;

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
        HealthManagement();
        Shoot();
    }

    void HealthManagement()
    {
        fHealth = fHealth;
        print(fHealth);
        healthBar.fillAmount = fHealth / 100;
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
        
  

    public void PickUp(BaseAttack NewSpell)
    {
        bool foundItem = false;
        int freeSpot = 0;
        for (int i = 0; i < myAttacks.Length; i++)
        {
            if (myAttacks[i] == null)
            {
                freeSpot = i;
                foundItem = true;
                
                break;
            }
        }
        if (foundItem)
        {
            myAttacks[freeSpot] = NewSpell;
        } else {
            //add functionality for current selected object to drop
            myAttacks[myCurrentObject] = NewSpell;
        }
        SetFrames();
    }

    void rotateAround()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isFiring)
        {
            StartCoroutine("waitFire");
        }
    }

    IEnumerator waitFire()
    {

        Instantiate(myAttacks[myCurrentObject].myProjectile, transform.position, transform.rotation);
        isFiring = false;
        yield return new WaitForSeconds(myAttacks[myCurrentObject].Rate);
        isFiring = true;
    }

}