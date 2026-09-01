using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPItemPotion : Identity
{
    public int healPoint = 20;
    public override void Hit()
    {
        mapGenerator.player.Heal(healPoint);
        Debug.Log("You got " + Name + " : " + healPoint);
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        Destroy(gameObject);
    }
}