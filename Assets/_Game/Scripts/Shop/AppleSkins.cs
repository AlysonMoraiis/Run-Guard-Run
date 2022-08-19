using UnityEngine;
using UnityEngine.UI;
using System;

public class AppleSkins : MonoBehaviour
{
    public Skins _skins;
    [SerializeField] private GameData _gameData;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private SkinSelect _skinSelect;
    [SerializeField] private Text _skinName;
    [SerializeField] private Text _skinPrice;
    [SerializeField] private ScaleWindow _scaleWindow;

    public event Action OnPurchase;

    public void UpdateSkinsInfo(Skins skins)
    {
        _skins = skins;
        _skinName.text = skins.SkinName;
        _skinPrice.text = "FOR " + skins.SkinPrice.ToString() + " APPLES?";
    }

    public void HandlePurchaseButton()
    {
        if(_gameData.Apple > _skins.SkinPrice)
        {
            _gameData.Apple -= _skins.SkinPrice;
            _skins.HasPurchased = true;
            _skinSelect.SetPlayerSelected(_skins.SkinIndex);
            _coinManager.TextUpdate();
            _scaleWindow.CloseWindowCall();
            OnPurchase?.Invoke();
        }
        else
        {
            Debug.Log("Buy more apples Popup");
        }
    }
}
