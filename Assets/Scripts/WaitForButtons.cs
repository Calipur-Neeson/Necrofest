using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForButtons : MonoBehaviour
{
    public GameObject buttons;
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        buttons.SetActive(true);
    }

}
