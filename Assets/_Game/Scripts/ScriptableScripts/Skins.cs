using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skin")]
public class Skins : ScriptableObject
{
    public string SkinName;
    public Sprite SkinImage;
    public int SkinPrice;
    public int SkinIndex;
    public bool HasPurchased;
}
