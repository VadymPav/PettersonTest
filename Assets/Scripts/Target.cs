using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public GameManager gameManager;

    private float value;
    private Color newColor;
    private float speed;

    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        value = Random.Range(0.5f, 3f);
        transform.localScale = new Vector3(value, value, 0f);
        speed = 10 / value;
        newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.material.color = newColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnMouseDown()
    {
        gameManager.IncrementScore(value);
        
        Destroy(gameObject);
    }
}
