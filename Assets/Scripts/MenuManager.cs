using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;

    void Start()
    {
        ShowHome(); // Show home by default
    }

    public void ShowHome()
    {
        homePanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void ShowAbout()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
