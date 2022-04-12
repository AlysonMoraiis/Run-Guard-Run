using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text _textScore;


    private void Update()
    {
        gameData.Highscore += 10 * Time.deltaTime;
        TextUpdate();
    }


    void TextUpdate()
    {
        int tScore = (int)gameData.Score;
        _textScore.text = tScore.ToString();
    }
}
