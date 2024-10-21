using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    /** References **/
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        PlayerController.Instance.Pause.performed += _ => TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf) ResumeGame();
        else PauseGame();
    }

    private void PauseGame() 
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    private void ResumeGame() 
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseMenu.GetComponent<PauseMenu>().CloseOptions();
    }
}
