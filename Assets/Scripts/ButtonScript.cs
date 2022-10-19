using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void StopButton()
    {
        SceneManager.LoadScene("Starter");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
