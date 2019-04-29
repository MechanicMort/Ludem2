using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrain : BaseAttack
{

    public SoulDrain()
    {
        AttackName = "Soul Drain";
        Damage = 1f;
        Cost = 40;
        Rate = 0.01f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
