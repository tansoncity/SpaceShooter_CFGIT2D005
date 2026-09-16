using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Scoring : MonoBehaviour
{
    public UnityEvent<int> ScoreChanged;

    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreChanged?.Invoke(_score);
        }
    }

    private void Start()
    {
        Score = 0;
        //Enemy.EnemyKilled += OnEnemyKill;
        Enemy.EnemyScored += OnEnemyScored;
    }

    private void OnDestroy()
    {
        //Enemy.EnemyKilled -= OnEnemyKill; 
        Enemy.EnemyScored -= OnEnemyScored;
    }

    private void OnEnemyScored(int enemyScore) => Score += enemyScore;
}