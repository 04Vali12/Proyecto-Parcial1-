using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public string Type;
    public string Description;
    public Sprite Icon;
    public string Name;

    [HideInInspector]
    public bool recogido;
}
