using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public bool isGameOver;
    
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && isGameOver)
        {
            isGameOver = false;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
