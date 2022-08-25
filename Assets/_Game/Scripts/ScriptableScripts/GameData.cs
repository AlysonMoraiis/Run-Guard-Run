using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    public float Score;
    public float Highscore;
    public int Apple;
    public int Pineapple;

    public bool ControlType;

    public bool SoundStats;

    public int DeathsCount;
}
