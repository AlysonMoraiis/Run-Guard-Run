using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSkinInSlot : MonoBehaviour
{
    [SerializeField] private Image _skinImage;
    [SerializeField] private Text _skinPrice;
    [SerializeField] private bool _hasPurchased;
    [SerializeField] private Skins _skins;
    [SerializeField] private GameObject _availableSkin;
    [SerializeField] private GameObject _purchasedSkin;

    private void Start()
    {
        SetSkin();
        if(_hasPurchased)
        {
            _availableSkin.SetActive(false);
            _purchasedSkin.SetActive(true);
        }
    }

    public void SetSkin()
    {
        _skinImage.sprite = _skins.SkinImage;
        _skinPrice.text = "$" + _skins.SkinPrice.ToString();
        _hasPurchased = _skins.HasPurchased;
    }
}
