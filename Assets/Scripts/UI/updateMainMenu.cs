using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class updateMainMenu : MonoBehaviour {

    /// <summary>
    /// Method to start the game
    /// </summary>
    public void startLevel ()
    {
        Debug.Log("spòdf <sdulkovgpfñsdxhi fñplgers .");
        SceneManager.LoadScene("Nivel_1");
    }

    /// <summary>
    /// Method to exit the game
    /// </summary>
    public void exitGame ()
    {
        Application.Quit();
    }

    /// <summary>
    /// Methos to show the points
    /// </summary>
    public void pointsLevel ()
    {
        SceneManager.LoadScene("ShowPoints");
    }
}
