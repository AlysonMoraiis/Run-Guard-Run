using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int BoyScoutSkinPrice = 0;
    private bool OwnBoyScoutSkin = false;
    [SerializeField] private int EletronicKidSkinPrice = 50;
    private int EletronicKidSkinID = 1;
    [SerializeField] private int MaskFaceSkinPrice = 500;
    private int MaskFaceSkinID = 2;
    [SerializeField] private int CrazyGuySkinPrice = 2500;
    private int CrazyGuySkinID = 3;

    [SerializeField] private GameData gameData;

    public void BuySkin(int skinId)
    {
        if(skinId == 0)
        {
            if (gameData.Coin > BoyScoutSkinPrice)
            {
                OwnBoyScoutSkin = true;
                gameData.Coin -= BoyScoutSkinPrice;
                SaveLoadSystem.Instance.Save();
            }
        }
    }

    private void OwnedSkins()
    {
        
    }
}
