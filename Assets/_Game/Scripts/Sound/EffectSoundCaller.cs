using UnityEngine;

public class EffectSoundCaller : MonoBehaviour
{
    [SerializeField] private AudioClip effectSound;


    void Start()
    {
        SoundManager.Instance.PlaySound(effectSound);
    }
}