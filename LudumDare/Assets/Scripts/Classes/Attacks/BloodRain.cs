﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRain : BaseAttack {

	public BloodRain ()
    {
        AttackName = "Blood Rain";
        Damage = 5;
        Cost = 1;
        Rate = 0.1f;
        ProjectileSpeed = 3;
        LifeSpan = 100;
    }
}
