using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : CollectibleItem
{
    public override void OnInteraction()
    {
        base.OnInteraction();
        Player.OnCollectiblePickUp(this.type);
    }
}
