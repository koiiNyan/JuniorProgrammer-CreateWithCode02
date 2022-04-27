using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField]
    private Text _scoresText;

    private void Awake()
    {
        PrintScores();
    }

    private void PrintScores()
    {
        string scoresString = string.Empty;

        var scores = SaveLoad.GetHighestScores();
        foreach (var score in scores)
            scoresString += $"{score.Name}: {score.Points}\n";

        _scoresText.text = scoresString;
    }
}
