using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    private int _score;

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
    public void AddScore(int value)
    {
        _score += value;
        UpdateScore(_score);
        Debug.Log("Score updated: " + _score);
    }
}
