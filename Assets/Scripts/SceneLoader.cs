using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
