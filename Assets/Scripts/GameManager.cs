using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool IsGameOver { get; private set; } = false;


    /** References **/
    [SerializeField] private GameObject pauseMenu;


    public Material interactableHighlightMaterial;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

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
        FindObjectOfType<AudioManager>().StopAll();
    }

    private void ResumeGame() 
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseMenu.GetComponent<PauseMenu>().CloseOptions();
        FindObjectOfType<AudioManager>().PlayMusic();
        FindObjectOfType<AudioManager>().PlayAmbient();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
