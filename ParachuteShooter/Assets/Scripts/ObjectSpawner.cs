using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private List<Sprite> objSpriteList = new List<Sprite>();

    private Camera _cam;
    private float _height;
    private float _width;
    private float objWidth;

    private void Start()
    {
        _cam = Camera.main;
        _height = 2f * _cam.orthographicSize;
        _width = _height * _cam.aspect;
        objWidth = _objectPrefab.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2;
        SpawnObjects();
    }

    private void SpawnObjects()
    {

        var range = UnityEngine.Random.Range(1.5f, 4f);
        var obj = Instantiate(_objectPrefab, new Vector2(-(_width / 2 + objWidth), range), Quaternion.identity);
        setSprite();
        Invoke(nameof(SpawnObjects), UnityEngine.Random.Range(2f, 3f));
    }

    private void setSprite()
    {
        int _spriteCounter= UnityEngine.Random.Range(0, objSpriteList.Count);
        _objectPrefab.transform.GetComponent<SpriteRenderer>().sprite = objSpriteList[_spriteCounter];

    }
    public static void Shuffle<T>(IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
