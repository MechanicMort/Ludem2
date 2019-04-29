using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingSkull : BaseAttack
{

    public LaughingSkull()
    {
        AttackName = "Laughing Skull";
        Damage = 10f;
        Cost = 20;
        Rate = 0.5f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
