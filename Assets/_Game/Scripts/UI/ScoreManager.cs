using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour, ISaveable
{
    [SerializeField] private GameData _gameData;
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
            _gameData.Score += 6 * Time.deltaTime;
            InGameTextUpdate();
        }
    }

    void InGameTextUpdate()
    {
        int tScore = (int)_gameData.Score;
        _inGameTextScore.text = tScore.ToString();
    }

    private void UpdateHighscore()
    {
        canCountScore = false;
        LastScore();
        if (lastScore > _gameData.Highscore)
        {
            _gameData.Highscore = lastScore;
        }
        UpdateHighscoreText();
        _gameData.Score = 0;
    }

    private void UpdateHighscoreText()
    {
        tHighscore = (int)_gameData.Highscore;
        _textAfterGameHighscore.text = tHighscore.ToString();
        _textMenuGameHighscore.text = tHighscore.ToString();
    }

    private void LastScore()
    {
        lastScore = _gameData.Score;
        int tLastScore = (int)_gameData.Score;
        _inGameLastScoreText.text = tLastScore.ToString();

    }

    public object SaveState()
    {
        Debug.Log("Save highscore: " + _gameData.Highscore);
        return new SaveData()
        {
            highscore = this._gameData.Highscore
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        _gameData.Highscore = saveData.highscore;
        Debug.Log("Load highscore" + _gameData.Highscore);
    }

    [Serializable]
    private struct SaveData
    {
        public float highscore;
    }
}
