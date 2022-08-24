using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour, ISaveable
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text _inGameTextScore;
    [SerializeField] private Text _inGameLastScoreText;
    [SerializeField] private Text _textAfterGameHighscore;
    [SerializeField] private Text _textMenuGameHighscore;
    [SerializeField] private PlayerCollisions playerCollisions;

    private int tHighscore;
    private float lastScore;
    private bool canCountScore = true;

    private void Start()
    {
        gameData.Score = 0;
        //tHighscore = (int)gameData.Highscore;
        //_textMenuGameHighscore.text = tHighscore.ToString();
        UpdateHighscoreText();
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
        UpdateHighscoreText();
    }

    private void UpdateHighscoreText()
    {
        tHighscore = (int)gameData.Highscore;
        _textAfterGameHighscore.text = tHighscore.ToString();
        _textMenuGameHighscore.text = tHighscore.ToString();
    }

    private void LastScore()
    {
        lastScore = gameData.Score;
        int tLastScore = (int)gameData.Score;
        _inGameLastScoreText.text = tLastScore.ToString();

    }

    public object SaveState()
    {
        Debug.Log("Save highscore: " + gameData.Highscore);
        return new SaveData()
        {
            highscore = this.gameData.Highscore
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        gameData.Highscore = saveData.highscore;
        Debug.Log("Load highscore" + gameData.Highscore);
    }

    [Serializable]
    private struct SaveData
    {
        public float highscore;
    }
}
