using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /** References **/
    [SerializeField] private GameObject optionsMenu;

    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenOptions() 
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
