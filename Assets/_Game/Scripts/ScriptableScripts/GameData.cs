using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    [Header("Player values")]
    public float Score;
    public float Highscore;
    public int Apple;
    public int Pineapple;

    [Header("Game checks")]
    public int DeathsCount;
    public bool ControlType;

    public bool SoundStats;
}
