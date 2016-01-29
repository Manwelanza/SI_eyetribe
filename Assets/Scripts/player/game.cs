using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

    private static int lifes = 3;
    private static float timeScale;
	// Use this for initialization
	void Start () {
        timeScale = Time.timeScale;
        updateLife.update();
    }
	
    public static void die ()
    {
        if (lifes > 0)
        {
            lifes--;
            updateLife.update();
        }

        else
        {
            gameOver();
        }
    }

    public static void gameOver ()
    {
        lifes = 0;
        updateLife.update();
        Time.timeScale = 0;
        //mostrar menu o hacer algo
    }

    public static int getLifes ()
    {
        return lifes;
    }
}
