using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    private float xMove;
    private float yMove;
    public float speed;


    public bool isFiring;
    public Camera mainCam;
    public Rigidbody2D rb;

    public BaseAttack[] myAttacks = new BaseAttack[4];

    public Image[] frames = new Image[4];
    public GameObject[] Selector = new GameObject[4];

    public int myCurrentObject;
    public static PlayerMovement player;

    public Image healthBar;
    public float fHealth;

    public AudioSource audio;


    void Wake()
    {
        
    }

    void Start()
    {
        if (PlayerMovement.player == null)
        {
            player = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
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
        HealthManagement();
        Shoot();
        Die();
        print(fHealth);
    }

    void TP(Transform tp)
    {
        transform.position = tp.position;
    }

    void Heal(float HP)
    {
        fHealth += HP;
    }

    void DamageDealt(float Damage)
    {
        fHealth -= Damage;
    }

    private void Die()
    {
        if (fHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void HealthManagement()
    {
        healthBar.fillAmount = fHealth / 100;
    }

    void changeSelected()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && myAttacks[0] != null)
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
        
  



    public void PickUp(BaseAttack NewSpell, GameObject Origin)
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
            Destroy(Origin);
        }
        else
        {
            Origin.GetComponent<PlayerPickUpTheThing>().myAttack = myAttacks[myCurrentObject];
            Origin.GetComponent<SpriteRenderer>().sprite = myAttacks[myCurrentObject].UIElement;
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

        GameObject Bullet = Instantiate(myAttacks[myCurrentObject].myProjectile, transform.position, transform.rotation);
        audio.clip = myAttacks[myCurrentObject].shootSound;
        audio.Play();
        Bullet.GetComponent<Player_BulletScript>().fDamage = myAttacks[myCurrentObject].Damage;
        isFiring = false;
        yield return new WaitForSeconds(myAttacks[myCurrentObject].Rate);
        isFiring = true;
    }

}