using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseAttack : MonoBehaviour {

    public string AttackName;

    public float Damage;
    public float Cost;
    public float Rate;
    public float LifeSpan;
    public float ProjectileSpeed;

    public GameObject myProjectile;
    public AudioClip shootSound;
    public Sprite UIElement;

}
