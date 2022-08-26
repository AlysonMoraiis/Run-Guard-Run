using UnityEngine;

[CreateAssetMenu(fileName = "RatedData")]
public class RatedData : ScriptableObject
{
    public bool HasRated;
    public int RestartCount;
}
