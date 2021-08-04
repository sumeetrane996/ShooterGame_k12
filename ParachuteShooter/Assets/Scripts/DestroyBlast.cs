using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlast : MonoBehaviour
{
    public void DestroyBlastPrefab()
    {
        Debug.Log("DestroyBlastPrefab");
        Destroy(gameObject);
    }
}
