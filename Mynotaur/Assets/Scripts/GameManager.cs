using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public int currentSceneIndex;

    [SerializeField] public GameObject pauseMenu;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }

        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            pauseMenu.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
