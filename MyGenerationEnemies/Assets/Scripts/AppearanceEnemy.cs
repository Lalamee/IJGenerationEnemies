using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AppearanceEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _dinosaur;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private float _delay = 2.0f;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(Spawn());
    }
    

    private IEnumerator Spawn()
    {
        var waitForDelay = new WaitForSeconds(_delay);
        
        for (int i = 0; i < _points.Length; i++)
        {
            yield return waitForDelay;
            Instantiate(_dinosaur, _points[i].transform.position, Quaternion.identity);
        }
        
        StopCoroutine(Spawn());
    }
}
