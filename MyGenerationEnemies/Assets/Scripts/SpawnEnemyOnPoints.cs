using UnityEngine;
using Random = System.Random;

public class SpawnEnemyOnPoints : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private float _spawnTime = 2.0f;
    private int _numberSpawnPoint = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (_spawnTime <= 0 && _numberSpawnPoint < _points.Length)
        {
            Instantiate(_enemy, _points[_numberSpawnPoint].transform.position, Quaternion.identity);
            _spawnTime = 2.0f;
            _numberSpawnPoint++;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }
    }
}
