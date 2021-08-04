using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private float _moveSpeed = 2.3f;
    private Camera _cam;
    private float _height;
    private float _width;
    private float objWidth;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _height = 2f * _cam.orthographicSize;
        _width = _height * _cam.aspect;
        _moveSpeed = UnityEngine.Random.Range(1.8f, 2.2f);

        objWidth = gameObject.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
    private void MoveObject()
    {
        var transform1 = transform;
        Vector2 tempPos = transform1.position;
        tempPos.x += _moveSpeed * Time.deltaTime;
        transform1.position = tempPos;

        if (!(tempPos.x >= (_width / 2 + objWidth))) return;

        GameObject o;
        (o = gameObject).SetActive(false);
        Destroy(o);
    }
}
