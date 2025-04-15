using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadGame()
    {

        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("TestWithRooms");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Death()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("DeathScreen");
        transitionAnim.SetTrigger("End"); 
    }
}

