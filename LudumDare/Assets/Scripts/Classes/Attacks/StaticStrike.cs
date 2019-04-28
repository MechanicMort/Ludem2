using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStrike : BaseAttack
{

    public StaticStrike()
    {
        AttackName = "StaticStrike";
        Damage = 20;
        Cost = 5;
        Rate = 0.1f;
    }
}
