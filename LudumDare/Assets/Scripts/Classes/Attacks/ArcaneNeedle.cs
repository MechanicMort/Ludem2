using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneNeedle : BaseAttack
{

    public ArcaneNeedle()
    {
        AttackName = "Arcane Needle";
        Damage = 4f;
        Cost = 5;
        Rate = 1;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
