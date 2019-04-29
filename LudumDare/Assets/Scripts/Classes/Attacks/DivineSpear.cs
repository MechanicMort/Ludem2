using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineSpear : BaseAttack
{

    public DivineSpear()
    {
        AttackName = "Divine Spear";
        Damage = 25;
        Cost = 25;
        Rate = 0.75f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
