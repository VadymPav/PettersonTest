using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class Fader : MonoBehaviour
{
    public Text levelName;
    public GameManager GameManager;

    private float fadeTime;
    private bool fadingIn;

    private void Start()
    {
        levelName.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = false;
    }

    private void Update()
    {
        if (fadingIn)
            FadeIn();
        else if (levelName.color.a != 0)
            levelName.CrossFadeAlpha(0, 0.5f, false);
    }

    void FadeIn()
    {
        levelName.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (levelName.color.a == 1 && fadeTime > 1.5f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }

    public void FadeStart()
    {
        fadingIn = true;
        levelName.text = "Level " + GameManager.lvlNumber.ToString();
    }
}