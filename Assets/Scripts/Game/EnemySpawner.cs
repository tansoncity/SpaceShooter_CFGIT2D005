using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawningScript _script;

    private int _numberOfEnemies;
    private int _destroyedEnemies;

    private void Start()
    {
        _numberOfEnemies = CalculateNumberOfEnemies();
        _destroyedEnemies = 0;
        StartCoroutine(PerformSpawningScript());
        Enemy.EnemyDestroyed += OnEnemyDestroy;
    }

    private IEnumerator PerformSpawningScript()
    {
        foreach (var formation in _script.Waves)
        {
            yield return new WaitForSeconds(formation.Delay);
            SpawnFormation(formation);
        }
    }

    private void SpawnFormation(Formation formation)
    {
        for (int i = 0; i < formation.EnemyCount; i++)
        {
            var traveller = Instantiate(formation.EnemyPrefab);
            traveller.SetRoute(formation.Route);
            traveller.SetStartDistance(i);
        }
    }

    private int CalculateNumberOfEnemies()
    {
        var count = 0;
        foreach (var formation in _script.Waves)
        {
            count += formation.EnemyCount;
        }
        return count;
    }

    private void OnDestroy() => Enemy.EnemyDestroyed -= OnEnemyDestroy;

    public void OnEnemyDestroy()
    {
        _destroyedEnemies++;
        if (_destroyedEnemies >= _numberOfEnemies)
        {
            OnAllEnemeyCleared();
        }
    }

    private void OnAllEnemeyCleared()
    {
        FindAnyObjectByType<GameFlow>().Victory();
        Destroy(this);
    }
}
