using UnityEngine;
using System.Collections;

public class updateGameOver : MonoBehaviour {

    private static Canvas gameOver;

	// Use this for initialization
	void Start () {
        gameOver = GameObject.Find ("gameOver").GetComponent<Canvas> ();
        gameOver.enabled = false;
	}
	
	public static void show () {
        gameOver.enabled = true;
    }
}
