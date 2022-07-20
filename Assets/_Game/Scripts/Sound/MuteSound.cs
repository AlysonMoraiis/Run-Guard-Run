using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private Sprite _enabledSound;
    [SerializeField] private Sprite _disabledSound;
    [SerializeField] private Button _musicButton;

    public void MuteAndUnmuteSoundCaller()
    {
        SpriteCheck();
        SoundManager.Instance.MuteAndUnmuteSound();
    }

    private void SpriteCheck()
    {
        if (SoundManager.Instance._musicSource.mute == true)
        {
            _musicButton.GetComponent<Image>().sprite = _enabledSound;
        }
        else
        {
            _musicButton.GetComponent<Image>().sprite = _disabledSound;
        }
    }
}
