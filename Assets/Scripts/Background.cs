using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Background : MonoBehaviour
{
    public Sprite[] newSprite;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        newSprite = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer.sprite = newSprite[Random.Range(0, newSprite.Length)];  
    }

}
