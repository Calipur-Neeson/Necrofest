using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLoader : MonoBehaviour
{
   public void LoadScene()
    {
        SceneManager.LoadScene("Settings");
    }
}
