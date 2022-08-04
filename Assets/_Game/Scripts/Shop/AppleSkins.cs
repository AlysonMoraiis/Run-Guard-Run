using UnityEngine;
using UnityEngine.UI;

public class AppleSkins : MonoBehaviour
{
    public Skins _skins;
    [SerializeField] private GameData _gameData;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private SkinSelect _skinSelect;
    [SerializeField] private Text _skinName;
    [SerializeField] private Text _skinPrice;

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
        }
        else
        {
            Debug.Log("Buy more apples Popup");
        }
    }
}
