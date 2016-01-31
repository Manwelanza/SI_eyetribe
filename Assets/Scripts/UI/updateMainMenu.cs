using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class updateMainMenu : MonoBehaviour {

    public void startLevel ()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    public void exitGame ()
    {
        Application.Quit();
    }
}
