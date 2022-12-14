using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Config config;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadSpecificScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadGame(string map_file_name) {
        config.map_file_name = map_file_name;
        SceneManager.LoadScene(1);
    }

    public void ResumeScene() {
        GameObject pause_menu_canvas = GameObject.Find("Pause Menu");
        pause_menu_canvas.GetComponent<CanvasGroup>().alpha = 0;
        pause_menu_canvas.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
