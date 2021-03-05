using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public static LevelLoader instance;

    private void Start()
    {
        instance = this;
    }



    public void LoadNextLevel(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }
    public void PlayGame()
    {
        LoadNextLevel("NarrativeExample");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        LoadNextLevel("MainMenu");
        Time.timeScale = 1f;
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
     
    }

    public Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }
    public int GetActiveSceneBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public string GetActiveScreenName()
    {
        return GetActiveScene().name;
    }
}
