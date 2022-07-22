using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    public float Score;
    public float Highscore;
    public float Coin;

    public bool ControlType;

    public bool SoundStats;
}
