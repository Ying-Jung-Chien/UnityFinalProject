using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class item : ScriptableObject
{
    public string itemName;
    public Sprite itemimage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;
}
