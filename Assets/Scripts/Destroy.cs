using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Start() 
    {
        DestroyMe();
    }
    private void DestroyMe()
    {
        Destroy(gameObject, 0.2f);
    }
}
