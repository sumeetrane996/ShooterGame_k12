using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "BulletTag")
        {
            Destroy(collision.gameObject);

            Instantiate(MouseHandler.Instance.blastAnimPref, gameObject.transform.position,Quaternion.identity);
            AudioManager.audioInstance.Play("BurstSound");

            Destroy(gameObject);
        }
    }
}
