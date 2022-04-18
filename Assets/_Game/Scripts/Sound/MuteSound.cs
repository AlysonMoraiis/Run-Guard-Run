using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public void  MuteAndUnmuteSoundCaller()
    {
        SoundManager.Instance.MuteAndUnmuteSound();
    }
}
