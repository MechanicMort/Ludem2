using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatWave : BaseAttack
{

    public HeatWave()
    {
        AttackName = "Heat Wave";
        Damage = 15;
        Cost = 35;
        Rate = 1f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
