using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class updateGameOver : MonoBehaviour {

    private static Canvas gameOver;

	// Use this for initialization
	void Start () {
        gameOver = GetComponent<Canvas> ();
        gameOver.enabled = false;
	}
	
	public static void show () {
        gameOver.enabled = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
