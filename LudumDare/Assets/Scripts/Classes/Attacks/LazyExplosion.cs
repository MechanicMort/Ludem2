using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyExplosion : BaseAttack
{

    public LazyExplosion()
    {
        AttackName = "Lazy Explosion";
        Damage = 100;
        Cost = 70;
        Rate = 5f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
