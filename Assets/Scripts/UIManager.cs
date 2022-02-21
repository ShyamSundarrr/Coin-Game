using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(GameManager.instance.CurrentlevelId);
    }
    public void OnClickNextLevel()
    {
        SceneManager.LoadScene(GameManager.instance.NextlevelId);
    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        GameManager.instance.Stopcount = true;
    }
    public void OnClickResume()
    {
        Time.timeScale = 1;
        GameManager.instance.Stopcount = false;
    }

}
