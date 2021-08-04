using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 50;

    Vector2 lookDirection;
    float lookAngle;

    public GameObject blastAnimPref;

    private Vector2 _canonPos;
    private Vector2 _bulletPos;

    public static MouseHandler Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        _canonPos = transform.position;
        _bulletPos = bullet.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            if (lookDirection.y > -1.5)
            {
                AudioManager.audioInstance.Play("ShootSound");

                var thetaRadians = Math.Atan2(lookDirection.y - _canonPos.y, lookDirection.x - _canonPos.x) * 180 / Math.PI;
                transform.DORotate(new Vector3(0, 0, (float)thetaRadians - 90), 0f);
            
                GameObject bulletClone = Instantiate(bullet);

                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;

            }

            
        }


    }

}
