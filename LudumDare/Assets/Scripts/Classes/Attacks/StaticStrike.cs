using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStrike : BaseAttack
{

    public StaticStrike()
    {
        AttackName = "Static Strike";
        Damage = 20;
        Cost = 5;
        Rate = 0.1f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
