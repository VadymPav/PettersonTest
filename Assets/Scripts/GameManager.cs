using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Target target;
    public Fader fader;
    
    

    private int score = 0;
    private int q = 0;
    public int lvlNumber = 1;
    //private Sprite sprite;
    [SerializeField] private Background background;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Respawn), 0f, 1.5f);
        fader.FadeStart();
    }

    // Update is called once per frame
    void Respawn()
    {
        for (int i = 1; i <= lvlNumber; i++) Spawn();
        
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
        
        if (value < 1){ 
            score += 3;
            q += 3;
        }
        else if (value >= 1 && value <= 2)
        {
            score += 2;
            q += 2;
        }
        else if (value > 2)
        {
            score += 1;
            q += 1;
        }
        scoreText.text = score.ToString();
        if (q >= 10) 
        {
            LevelUp();
            q -= 10;
        }
    }

    private void LevelUp()
    {
        lvlNumber += 1;
        background.Start();
        fader.FadeStart();
    }
}
