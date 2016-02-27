using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class updateGameOver : MonoBehaviour {

    private static Canvas gameOver;
    private static Text score;

	// Use this for initialization
	void Start () {
        gameOver = GetComponent<Canvas> ();
        gameOver.enabled = false;
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text i in texts)
        {
            if (i.gameObject.name == "points")
            {
                score = i;
            }
        }
	}
	
	public static void show () {
        gameOver.enabled = true;
        score.text = updatePoints.getPoints().ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainMenu");
        game.startGame();
    }
}
