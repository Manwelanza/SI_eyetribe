using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;
using SpaceInvaders;

public class updateGameOver : MonoBehaviour {

    private static Canvas gameOver;
    private static Text score;
    private static InputField input;
    private static string player;

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

        input = GetComponentInChildren<InputField>();
        InputField.OnChangeEvent se = new InputField.OnChangeEvent();
        se.AddListener(EditInput);
        input.onValueChanged = se;
	}

    public void EditInput (string arg0)
    {
        player = arg0;
    }
	
	public static void show () {
        gameOver.enabled = true;
        score.text = updatePoints.getPoints().ToString();
        input.ActivateInputField();
        input.Select();
    }

    public void startGame()
    {
        Points.stateGame.Save(new PlayerPoint(player, updatePoints.getPoints()));
        SceneManager.LoadScene("MainMenu");
        game.startGame();
    }

}
