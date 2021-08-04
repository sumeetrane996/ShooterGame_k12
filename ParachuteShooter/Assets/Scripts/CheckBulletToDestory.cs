using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBulletToDestory : MonoBehaviour
{
    Vector2 bulletPos;
    float screenHeight,screenWidth;
    private void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        Debug.Log(screenWidth + "  " + screenHeight);
    }
    private void Update()
    {
        bulletPos = transform.position;
        //Debug.Log(bulletPos);

        if(bulletPos.x> screenWidth|| bulletPos.x < -screenWidth)
        {
            //Debug.Log("x out");
            Destroy(gameObject);

        }else if(bulletPos.y> screenHeight|| bulletPos.y < -screenHeight)
        {
            //Debug.Log("y out");
            Destroy(gameObject);

        }
    }
}
