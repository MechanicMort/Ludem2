using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneAnnihilation : BaseAttack
{

    public ArcaneAnnihilation()
    {
        AttackName = "Arcane Annihilation";
        Damage = 100;
        Cost = 10;
        Rate = 5f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
