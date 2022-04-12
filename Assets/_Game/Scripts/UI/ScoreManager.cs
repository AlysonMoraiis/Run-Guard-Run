using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text _inGameTextScore;
    [SerializeField] private Text _textLastScore;
    [SerializeField] private Text _textAfterGameHighscore;
    [SerializeField] private Text _textMenuGameHighscore;
    [SerializeField] private PlayerCollisions playerCollisions;

    private int tHighscore;
    private float lastScore;

    private bool canCountScore = true;


    private void Start()
    {
        gameData.Score = 0;
        tHighscore = (int)gameData.Highscore;
        _textMenuGameHighscore.text = tHighscore.ToString();
    }


    private void OnEnable()
    {
        playerCollisions.OnDeath += UpdateHighscore;
    }


    private void OnDisable()
    {
        playerCollisions.OnDeath -= UpdateHighscore;
    }


    private void Update()
    {
        if (canCountScore)
        {
            gameData.Score += 10 * Time.deltaTime;
            InGameTextUpdate();
        }
    }


    void InGameTextUpdate()
    {
        int tScore = (int)gameData.Score;
        _inGameTextScore.text = tScore.ToString();
    }


    private void UpdateHighscore()
    {
        canCountScore = false;
        LastScore();
        if (lastScore > gameData.Highscore)
        {
            gameData.Highscore = lastScore;
        }
        tHighscore = (int)gameData.Highscore;
        _textAfterGameHighscore.text = tHighscore.ToString();
        _textMenuGameHighscore.text = tHighscore.ToString();
    }


    private void LastScore()
    {
        lastScore = gameData.Score;
        int tLastScore = (int)gameData.Score;
        _textLastScore.text = tLastScore.ToString();
    }
}