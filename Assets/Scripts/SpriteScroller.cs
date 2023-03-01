using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    private Vector2 offset;
    private Material material;

    private void Awake() 
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update() 
    {
        ScrollSprite();
    }

    private void ScrollSprite()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
