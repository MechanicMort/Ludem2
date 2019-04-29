using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blight : BaseAttack
{

    public Blight()
    {
        AttackName = "Blight";
        Damage = 30;
        Cost = 50;
        Rate = 0.75f;
    }
}
