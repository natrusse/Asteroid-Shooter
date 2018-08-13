using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject infoUI;

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            GameOverUI.SetActive(true);
            infoUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
