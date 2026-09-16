using TMPro;
using UnityEngine;

public class ScoreTextBinder : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Scoring _scoring;

    private void Start() 
        => _scoring.ScoreChanged.AddListener(OnScoreChanged);

    private void OnDestroy() 
        => _scoring.ScoreChanged.RemoveListener(OnScoreChanged);

    private void OnScoreChanged(int newScore) 
        => _scoreText.text = $"Score: {newScore}";
}
