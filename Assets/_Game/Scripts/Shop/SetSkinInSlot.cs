using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SetSkinInSlot : MonoBehaviour
{
    [SerializeField] private Image _skinImage;
    [SerializeField] private Text _skinPrice;
    [SerializeField] private bool _hasPurchased;
    [SerializeField] private Skins _skins;
    [SerializeField] private GameObject _availableSkin;
    [SerializeField] private GameObject _purchasedSkin;
    [SerializeField] private AppleSkins _appleSkins;
    [SerializeField] private int _skinIndex;
    [SerializeField] private Button _skinSelectButton;
    [SerializeField] private SkinSelect _skinSelect;


    void OnEnable()
    {
        _appleSkins.OnPurchase += Refresh;
        _skinSelect.OnEquip += Refresh;
    }

    void OnDisable()
    {
        _appleSkins.OnPurchase -= Refresh;
        _skinSelect.OnEquip -= Refresh;
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        _skinSelectButton.interactable = true;
        SetSkin();
        if (_hasPurchased)
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
        if (_skinIndex == _skinSelect._index)
        {
            _skinSelectButton.interactable = false;
        }
    }
}
