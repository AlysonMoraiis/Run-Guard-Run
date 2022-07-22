using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private Sprite _enabledSound;
    [SerializeField] private Sprite _disabledSound;
    [SerializeField] private Button _musicButton;
    [SerializeField] private GameData _gameData;

    private void Start()
    {
        SpriteCheck();
    }

    public void MuteAndUnmuteSoundCaller()
    {
        _gameData.SoundStats = !_gameData.SoundStats;
        SpriteCheck();
        SoundManager.Instance.MuteAndUnmuteSound();

    }

    private void SpriteCheck()
    {
        if (_gameData.SoundStats == true)
        {
            _musicButton.GetComponent<Image>().sprite = _enabledSound;
            return;
        }
        _musicButton.GetComponent<Image>().sprite = _disabledSound;
    }
}
