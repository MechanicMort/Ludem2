using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernalMalice : BaseAttack
{

    public InfernalMalice()
    {
        AttackName = "Infernal Malice";
        Damage = 20;
        Cost = 20;
        Rate = 0.3f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
