using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class item : ScriptableObject
{
    public string itemName;
    public Sprite itemimage;
    public Sprite itemimage1;
    public int itemHeld;
    public int itemType;
    public int itemactive;
    [TextArea]
    public string itemInfo;
}
