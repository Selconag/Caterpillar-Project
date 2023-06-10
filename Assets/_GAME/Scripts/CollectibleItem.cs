using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CollectibleType { Food, Magnet, Stopwatch, Laser}
public class CollectibleItem : MonoBehaviour
{
    [SerializeField] protected CollectibleType type;

    public virtual void OnInteraction()
    {

    }
}
