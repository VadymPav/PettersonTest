using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject target;

    private int score = 0;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn();
        
        InvokeRepeating("Spawn", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(6f, 8f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    public void IncrementScore(float value)
    {
        if (value < 1) score += 3;
        else if (value >= 1 && value <= 2) score += 2;
        else if (value > 2) score += 1;

            scoreText.text = score.ToString();
    }
}
