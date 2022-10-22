using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour, IPointerDownHandler
{
    public GameManager gameManager;
    
    private Renderer _renderer;
    private Color newColor;
    
    private float value;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        value = Random.Range(0.5f, 3f);
        transform.localScale = new Vector3(value, value, 0f);
        speed = (5 * gameManager.lvlNumber) / value;
        print(speed);
        newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.material.color = newColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.IncrementScore(value);
        
        Destroy(gameObject);
    }
}
