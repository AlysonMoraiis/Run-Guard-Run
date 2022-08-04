using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallPurchasePopup : MonoBehaviour
{
    [SerializeField] private ScaleWindow _scaleWindow;
    [SerializeField] private AppleSkins _appleSkins;
    [SerializeField] private SkinSelect _skinSelect;
    [SerializeField] private Skins _skins;
    [SerializeField] private Button _skinSelectButton;

    public void HandleSkinButton()
    {
        if (_skins.HasPurchased)
        {
            _skinSelect.SetPlayerSelected(_skins.SkinIndex);
            _skinSelectButton.interactable = false;
            return;
        }
        _appleSkins.UpdateSkinsInfo(_skins);
        _scaleWindow.OpenWindow();
    }

}
