using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject
{
    public enum SkinIDs { skin1, skin2, skin3, skin4}
    public SkinIDs skinID;

    public Sprite skinSprite;

    public int skinPrice;
}
